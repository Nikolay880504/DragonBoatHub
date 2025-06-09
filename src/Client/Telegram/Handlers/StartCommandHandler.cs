
using Telegram.Bot.Types.ReplyMarkups;
using MinimalTelegramBot.Results;
using Results = MinimalTelegramBot.Results.Results;
using MinimalTelegramBot.StateMachine.Abstractions;
using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using DragonBoatHub.TelegramBot.DragonBot.States;
using DragonBot.Localization.Interfases;

namespace DragonBoatHub.TelegramBot.DragonBot.Handlers
{
    internal class StartCommandHandler : IHandler
    {
        private readonly IStateMachine _stateMachine;
        private readonly IEnumerable<ISupportedLocale> _supportedLocales;

        public StartCommandHandler(IStateMachine stateMachine, IEnumerable<ISupportedLocale> supportedLocales)
        {
            _stateMachine = stateMachine;
            _supportedLocales = supportedLocales;
        }
        public IResult HandleAsync()
        {
            _stateMachine.SetState(LanguageChoiceState.state);

            var languageKeyboardMarkup = new ReplyKeyboardMarkup(
            _supportedLocales.Select(locale => new KeyboardButton(locale.NameButton)).ToArray())

            {
                ResizeKeyboard = true
            };

            return Results.Message(string.Join(" / ", _supportedLocales.Select(locale => locale.Message)),
                                   keyboard: languageKeyboardMarkup);
        }
    }
}
