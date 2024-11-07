using DragonBoatDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBoatDomain.Interfases
{
    public interface ITrainingRepository
    {
        Task<IEnumerable<TrainingSession>> GetAvailableSessionsAsync();
    }
}
