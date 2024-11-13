
using DragonBoatHub.TelegramBot.DragonBot.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DragonBoatHub.TelegramBot.DragonBot.Handlers
{
    internal class CommandFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IHandler GetRequiredHendler(string commandName) 
        {          
            return commandName switch
            {
                "/start" => _serviceProvider.GetRequiredService<UserStatusHandler>(),
                "singup" => _serviceProvider.GetRequiredService<SingUpHandler>(),
                _ => throw new ArgumentException("Команда не распознана.")
            };
        }
    }
}
