using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAiChatBotApi.ChatBots.Gpt
{
    public class GptContextHistory
    {
        public List<Dictionary<string, string>> History { get; }

        public GptContextHistory()
        {
            History = new List<Dictionary<string, string>>();
        }

        public void AddUserMessage(string userMessage)
        {
            History.Add(new Dictionary<string, string> { { "role", "user" }, { "content", userMessage } });
        }

        public void AddChatMessage(string chatMessage)
        {
            History.Add(new Dictionary<string, string> { { "role", "assistant" }, { "content", chatMessage } });
        }

        public void clear()
        {
            History.Clear();
        }
    }
}
