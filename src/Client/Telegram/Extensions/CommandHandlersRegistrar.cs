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
                => languageChoice.HandleAsync()).FilterState(LanguageChoiceState.state);
            app.Handle(([FromServices] AvailableTrainingsHandler mainMenu) 
                => mainMenu.HandleAsync()).FilterState(MainMenuButtonsState.state).
                FilterMessageTextWithLocalizer("Button.SignUpForTraining");
            app.Handle(([FromServices] RequestPhoneNumberHandler singUp) 
                => singUp.HandleAsync()).FilterState(RequestPhoneNumberState.state).
                FilterMessageTextWithLocalizer("Button.Registration");
            app.Handle(([FromServices] RequestFirstNameHandler requestFirstName) 
                => requestFirstName.HandleAsync()).FilterState(RequestFirstNameState.state);
            app.Handle(([FromServices] RequestLastNameHandler requestLastName) 
                => requestLastName.HandleAsync()).FilterState(RequestLastNameState.state);
            app.Handle(([FromServices] UserBirthDayHandler userBirthDayHandler ) 
                => userBirthDayHandler.HandleAsync()).FilterState(UserBirthDayState.state);
            app.Handle(([FromServices] ChooseTrainingLevelHandler chooseTrainingLevel) 
                => chooseTrainingLevel.HandleAsync()).FilterState(ChooseTrainingLevelState.state);
            app.Handle(([FromServices] UserRegistrationStatusHandler userRegistration) 
                => userRegistration.HandleAsync()).FilterState(UserRegistrationStatusState.state);
           
        }
    }
}
