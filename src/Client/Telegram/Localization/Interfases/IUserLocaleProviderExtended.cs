using MinimalTelegramBot.Localization.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBot.Localization.Interfases
{
    internal interface IUserLocaleProviderExtended : IUserLocaleProvider
    {


      //  public Task<Locale> GetUserLocaleAsync(long userId, CancellationToken cancellationToken = default);

        public Task SetUserLocaleAsync(long userId, Locale locale, CancellationToken cancellationToken = default);

        public Task AddUserAsync(long? userId, Locale locale, CancellationToken cancellationToken = default);

        public Task RemoveUserAsync(long userId, CancellationToken cancellationToken = default);
    }
}

