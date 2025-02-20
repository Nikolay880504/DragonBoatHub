using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBoatHub.API.Application.Intrfaces
{
    public interface IUserService
    {
        Task SetUserLocaleAsync(long telegramUserId, string locale);
        Task<string?> GetUserLocleAsync(long telegramUserId);
        Task<bool> CheckRegistractionByTelegramIdAsync(long? userId);
    }
}
