using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using MinimalTelegramBot.Results;
using Results = MinimalTelegramBot.Results.Results;
using MinimalTelegramBot.StateMachine.Abstractions;
using DragonBoatHub.TelegramBot.DragonBot.States;
using Telegram.Bot.Types;

namespace DragonBoatHub.TelegramBot.DragonBot.Handlers
{
    internal class StartCommandHandler
    {
        private readonly IStateMachine _stateMachine;

        public StartCommandHandler(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public async Task<IResult> HandleAsync()
        {    
            _stateMachine.SetState(LanguageChoiceState.state);
            var keyboardMarkup = new ReplyKeyboardMarkup(new[]
           {
             new KeyboardButton[] { "English 🇬🇧","Slovenski 🇸🇮"},
             })
            {
                ResizeKeyboard = true,
            };
            return Results.Message("Choose your language / Izberite jezik:", keyboard: keyboardMarkup);
        }
    }
}
