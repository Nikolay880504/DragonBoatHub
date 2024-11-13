using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DragonBoatHub.TelegramBot.DragonBot.HttpClient.ModelDto;

namespace DragonBoatHub.TelegramBot.DragonBot.HttpClient
{
    internal class TrainingService
    {
        private readonly ITrainingApiClient _client;

        public TrainingService(ITrainingApiClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<TrainingSessionDto>> GetTrainingSchedule() { 
        
         var models = await _client.GetAvailableSessionsAsync();

            return models;
        }
    }
}
