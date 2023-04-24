using Newtonsoft.Json;
using RestSharp;
using System.ComponentModel;
using OpenAiChatBotApi.ChatBots.CommonInterfaces;
using OpenAiChatBotApi.ChatBots.TextDavinci.Enums;
using OpenAiChatBotApi.ChatBots.TextDavinci.Interfaces;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace OpenAiChatBotApi.ChatBots.TextDavinci
{
    public class DavinciChatBot : IChatBot
    {
        protected DavinciBotModels Model;
        protected string ApiKey;
        protected string Stop;
        protected int Temperarure;
        protected int N;
        protected int Top_p;
        protected int Max_tokens;

        public IDavinciPrompt ConversationHistory { get; set; }

        public DavinciChatBot(DavinciBotModels model, string apiKey, IDavinciPrompt Prompt)
        {
            Model = model;
            ApiKey = apiKey;
            Temperarure = 1;
            N = 1;
            Top_p = 1;
            Max_tokens = 350;
            Stop = "";
            ConversationHistory = Prompt;
        }

        public DavinciChatBot(DavinciBotModels model, string apiKey, IDavinciPrompt Prompt, string stop, int temperature, int n, int top_p, int max_tokens)
        {
            Model = model;
            ApiKey = apiKey;
            Temperarure = temperature;
            N = n;
            Top_p = top_p;
            Max_tokens = max_tokens;
            Stop = stop;
            ConversationHistory = Prompt;
        }

        public void ClearConversation()
        {
            ConversationHistory.SetPromptToDefault();
        }

        //Sends a user request and retrieves bot`s answer
        public string SendRequest(string message)
        {
            try
            {
                //Adding user message to Conversation history to provide more context for the chat
                ConversationHistory.AddUserLine(message);

                //Making rest client
                var client = new RestClient("https://api.openai.com/v1");

                //Getting response on generated API request from GenerateInternalRestRequest func 
                RestResponse response = client.Execute(GenerateInternalRestRequest(message));

                //*** Begin parsing json response data
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = response.Content;
                    dynamic jsonResponseObj = JsonConvert.DeserializeObject(json);
                    string DavinciResponseContent = jsonResponseObj.choices[0].text;

                    //Adding parsed chat message to Conversation history to provide more context for it
                    ConversationHistory.AddRespondLine(DavinciResponseContent);

                    return DavinciResponseContent;
                }
                else
                    throw new Exception("Error processing API request");
                //***
            }
            catch (Exception ex)
            {
                ClearConversation();
                return $"Something`s gone wrong: {ex.Message},\n Bot will be restarted";
            }
        }

        //Sends a user request and retrieves bot`s answer
        public async Task<string> SendRequestAsync(string message)
        {
            try
            {
                //Adding user message to Conversation history to provide more context for the chat
                ConversationHistory.AddUserLine(message);

                //Making rest client
                var client = new RestClient("https://api.openai.com/v1");

                //Getting response on generated API request from GenerateInternalRestRequest func 
                RestResponse response = await client.ExecuteAsync(GenerateInternalRestRequest(message));

                //*** Begin parsing json response data
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = response.Content;
                    dynamic jsonResponseObj = JsonConvert.DeserializeObject(json);
                    string DavinciResponseContent = jsonResponseObj.choices[0].text;

                    //Adding parsed chat message to Conversation history to provide more context for it
                    ConversationHistory.AddRespondLine(DavinciResponseContent);

                    return DavinciResponseContent;
                }
                else
                    throw new Exception("Error processing API request");
                //***
            }
            catch (Exception ex)
            {
                ClearConversation();
                return $"Something`s gone wrong: {ex.Message},\n Bot will be restarted";
            }
        }

        protected RestRequest GenerateInternalRestRequest(string message)
        {
            var request = new RestRequest("completions", Method.Post);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {ApiKey}");

            var requestData = new
            {
                model = ParseGptModel(),
                temperature = Temperarure,
                max_tokens = Max_tokens,
                n = N,
                top_p = Top_p,
                stop = Stop,
                prompt = ConversationHistory.Context
            };

            request.AddBody(requestData);

            return request;
        }

        protected string ParseGptModel()
        {
            string Parsedmodel = (Model.GetType().
                GetMember(Model.ToString()).
                FirstOrDefault()?.
                GetCustomAttributes(typeof(DescriptionAttribute), false).
                FirstOrDefault() as DescriptionAttribute)?.
                Description ?? string.Empty;

            return Parsedmodel;
        }
    }
}
