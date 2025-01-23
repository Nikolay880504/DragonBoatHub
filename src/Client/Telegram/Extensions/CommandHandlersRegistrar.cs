using DragonBoatHub.TelegramBot.DragonBot.Handlers;
using Microsoft.AspNetCore.Mvc;
using MinimalTelegramBot.Builder;
using MinimalTelegramBot.Handling;
using MinimalTelegramBot.Handling.Filters;
using MinimalTelegramBot.StateMachine.Extensions;
using DragonBoatHub.TelegramBot.DragonBot.States;
using DragonBot.Handlers;
using DragonBot.States;
using MinimalTelegramBot.Localization.Extensions;


namespace DragonBot.Extensions
{
    internal static class CommandHandlersRegistrar
    {
        public static void UseBotHandlers(this BotApplication app)
        {
            app.Handle(([FromServices] StartCommandHandler startCommandHandler) => startCommandHandler.HandleAsync()).
                 FilterCommand("/start");

            app.Handle(([FromServices] LanguageChoiceHandler languageChoice) => languageChoice.HandleAsync()).FilterState(LanguageChoiceState.state);

            app.Handle(([FromServices] AvailableTrainingsHandler mainMenu) => mainMenu.HandleAsync()).FilterState(MainMenuButtonsState.state).
                FilterMessageTextWithLocalizer("Button.SignUpForTraining");
        }
    }
}
