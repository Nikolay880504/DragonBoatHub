using Microsoft.Extensions.DependencyInjection;
using MinimalTelegramBot.Localization.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBot.Localization.Interfases;

namespace DragonBot.Localization
{
    public class UserLocaleProvider : IUserLocaleProvider

    {

        private readonly Dictionary<long, Locale> _userLocales = new();

     
        public Task<Locale> GetUserLocaleAsync(long userId, CancellationToken cancellationToken = default)
        {
            if (_userLocales.ContainsKey(userId))
            {
                return Task.FromResult(_userLocales[userId]);
            }
            return Task.FromResult(new Locale("sl"));
        }
     

        public Task SetUserLocaleAsync(long userId, Locale locale, CancellationToken cancellationToken = default)
        {
            _userLocales[userId] = locale;
            return Task.CompletedTask;
        }

        public Task AddUserAsync(long? userId, Locale locale, CancellationToken cancellationToken = default)
        {/*
            if (!_userLocales.ContainsKey(userId))
            {
                _userLocales[userId] = locale;
            }
            */
            return Task.CompletedTask;
        }

        
        public Task RemoveUserAsync(long userId, CancellationToken cancellationToken = default)
        {
            _userLocales.Remove(userId);
            return Task.CompletedTask;
        }
    }

}
