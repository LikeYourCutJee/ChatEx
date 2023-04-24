using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAiChatBotApi.ChatBots.Gpt.Enums
{
    public enum GptModels
    {
        [Description("gpt-3.5-turbo")]
        gpt3_5_turbo,

        [Description("gpt-3.5-turbo-0301")]
        gpt3_5_turbo_0301
    }
}
