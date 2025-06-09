using MinimalTelegramBot.Localization.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBot.Localization.Interfases
{
    interface IUserLocaleCache
    {
        void UpdateLocalCache(long userId, string locale);
        Task<Locale> GetUserLocaleAsync(long userId);
    }
      
}
