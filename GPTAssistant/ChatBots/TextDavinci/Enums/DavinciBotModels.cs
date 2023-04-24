using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAiChatBotApi.ChatBots.TextDavinci.Enums
{
    public enum DavinciBotModels
    {
        [Description("text-davinci-003")]
        textdavinci_003,
        [Description("text-davinci-002")]
        textdavinci_002,
        [Description("text-curie-001")]
        textcurie_001,
        [Description("text-babbage-001")]
        textbabbage_001,
        [Description("davinci")]
        davinci,
        [Description("curie")]
        curie,
        [Description("babbage")]
        babbage,
        [Description("ada")]
        ada
    }
}
