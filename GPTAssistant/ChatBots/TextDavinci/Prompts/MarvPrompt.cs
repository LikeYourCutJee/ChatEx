using OpenAiChatBotApi.ChatBots.TextDavinci.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAiChatBotApi.ChatBots.TextDavinci.Prompts
{
    public class MarvPrompt : IDavinciPrompt
    {
        public string Context { get; set; }

        public MarvPrompt()
        {
            Context = "Marv is a chatbot that reluctantly answers questions with sarcastic responses:\n\n";
        }

        public void AddRespondLine(string responseLine)
        {
            Context += $"{responseLine}\n";
        }

        public void AddUserLine(string userline)
        {
            Context += $"User: {userline}\n";
        }

        public void SetPromptToDefault()
        {
            Context = "Marv is a chatbot that reluctantly answers questions with sarcastic responses:\n\n";
        }
    }
}
