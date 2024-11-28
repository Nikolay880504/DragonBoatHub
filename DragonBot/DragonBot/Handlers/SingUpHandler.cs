using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient;
using Telegram.Bot.Types.ReplyMarkups;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient.ModelDto;


namespace DragonBoatHub.TelegramBot.DragonBot.Handlers
{
    internal class SingUpHandler : IHandler
    {
        private readonly ITrainingApiClient _trainingApiClient;

        public SingUpHandler(ITrainingApiClient trainingApiClient)
        {
            _trainingApiClient = trainingApiClient;
        }
        public async Task HandleAsync(Update update, ITelegramBotClient client)
        {
            List<TrainingSessionDto> model = await _trainingApiClient.GetAvailableSessionsAsync();

            var chatId = update.Message.Chat.Id;

            ReplyKeyboardMarkup replyKeyboardMarkup = CreateCheckboxKeyboardMarkup(model);

            await client.SendTextMessageAsync(chatId, "Choose preferred training day:", replyMarkup: replyKeyboardMarkup);
        }

        private ReplyKeyboardMarkup CreateCheckboxKeyboardMarkup(List<TrainingSessionDto> trainingSessions)
        {
           
            KeyboardButton[][] buttons = new KeyboardButton[trainingSessions.Count][];

            for (int i = 0; i < trainingSessions.Count; i++)
            {
               
                buttons[i] = new KeyboardButton[] { new KeyboardButton($"{trainingSessions[i].StartDate}") };
            }
           
            return new ReplyKeyboardMarkup(buttons)
            {
                ResizeKeyboard = true 
            };
        }

    }
}
