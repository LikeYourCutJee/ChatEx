using OpenAiChatBotApi.ChatBots.TextDavinci.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAiChatBotApi.ChatBots.TextDavinci.Prompts
{
    public class DavinciPrompt : IDavinciPrompt
    {
        public string Context { get; set; }

        public DavinciPrompt()
        {
            Context = string.Empty;
        }

        public void AddRespondLine(string responseLine)
        {
            Context += $"{responseLine}\n";
        }

        public void AddUserLine(string userline)
        {
            Context += $"Human: {userline}\n";
        }

        public void SetPromptToDefault()
        {
            Context = string.Empty;
        }
    }
}
