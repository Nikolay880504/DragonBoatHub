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
            app.Handle(([FromServices] StartCommandHandler startCommandHandler) 
                => startCommandHandler.HandleAsync()).FilterCommand("/start");
            app.Handle(([FromServices] LanguageChoiceHandler languageChoice)
                => languageChoice.HandleAsync()).FilterState(LanguageChoiceState.State);
            app.Handle(([FromServices] MainMenuButtonsHandler mainMenu)
                => mainMenu.Handle()).FilterMessageTextWithLocalizer("Button.MainMenu");
            app.Handle(([FromServices] RequestPhoneNumberHandler singUp)
                => singUp.Handle()).FilterState(RequestPhoneNumberState.State);
            app.Handle(([FromServices] RequestFirstNameHandler requestFirstName) 
                => requestFirstName.HandleAsync()).FilterState(RequestFirstNameState.State);
            app.Handle(([FromServices] RequestLastNameHandler requestLastName) 
                => requestLastName.HandleAsync()).FilterState(RequestLastNameState.State);
            app.Handle(([FromServices] UserBirthDayHandler userBirthDayHandler ) 
                => userBirthDayHandler.HandleAsync()).FilterState(UserBirthDayState.State);
            app.Handle(([FromServices] ChooseTrainingLevelHandler chooseTrainingLevel) 
                => chooseTrainingLevel.HandleAsync()).FilterState(ChooseTrainingLevelState.State);
            app.Handle(([FromServices] UserRegistrationStatusHandler userRegistration) 
                => userRegistration.HandleAsync()).FilterState(UserRegistrationStatusState.State);
            app.Handle(([FromServices] SingUpForTrainingHandler singForTraining)
                => singForTraining.HandleAsync()).FilterMessageTextWithLocalizer("Button.SignUpForTraining");
            app.Handle(([FromServices] SingUpForTrainingHandler singForTraining)
                => singForTraining.HandleAsync())
                .FilterState(SingUpForTrainingState.State);
            app.Handle(([FromServices] SaveTrainingSessionForUser saveTrainingSessionFor)
                => saveTrainingSessionFor.HandleAsync()).FilterState(SaveTrainingSessionForUserState.State);            
        }
    }
}
