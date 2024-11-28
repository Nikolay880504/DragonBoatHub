using DragonBoatHub.TelegramBot.DragonBot.Handlers;
using Microsoft.AspNetCore.Mvc;
using MinimalTelegramBot.Builder;
using MinimalTelegramBot.Handling;
using MinimalTelegramBot.Handling.Filters;
using MinimalTelegramBot.StateMachine.Extensions;
using DragonBoatHub.TelegramBot.DragonBot.States;
using MinimalTelegramBot.StateMachine;


namespace DragonBot.Extensions
{
    internal static class CommandHandlersRegistrar
    {
        public static void UseBotHandlers(this BotApplication app)
        {
            app.Handle(([FromServices] StartCommandHandler startCommandHandler) => startCommandHandler.HandleAsync()).
                 FilterCommand("/start");
            app.Handle(([FromServices] SlovenianSelectionHandler userStatusHandler) => userStatusHandler.HandleAsync()).
               FilterState(LanguageChoiceState.state);
        }
    }
}
