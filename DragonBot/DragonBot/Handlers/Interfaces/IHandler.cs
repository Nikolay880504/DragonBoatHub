using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DragonBot.Handlers.Interfaces
{
    internal interface IHandler
    {
        Task HandleAsync(Update update, ITelegramBotClient client);
    }
}
