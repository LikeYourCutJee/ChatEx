using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAiChatBotApi.ChatBots.TextDavinci.Interfaces
{
    public interface IDavinciPrompt
    {
        string Context { get; set; }
        void AddUserLine(string userLine);
        void AddRespondLine(string responseLine);
        void SetPromptToDefault();

    }
}
