using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient;


namespace DragonBoatHub.TelegramBot.DragonBot.Handlers
{
    internal class SingUpHandler : IHandler
    {
        private readonly TrainingService _trainingService;

        public SingUpHandler(TrainingService trainingService)
        {
            _trainingService = trainingService;
        }
        public async Task HandleAsync(Update update, ITelegramBotClient client) {
            var model = await _trainingService.GetTrainingSchedule();

            foreach (var item in model)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}
