using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAiChatBotApi.ChatBots.CommonInterfaces
{
    public interface IChatBot
    {
        string SendRequest(string message);
        Task<string> SendRequestAsync(string message);
        void ClearConversation();
    }
}
