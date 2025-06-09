

using System.ComponentModel.DataAnnotations;

namespace DragonBoatHub.Contracts
{
  public  class TrainingSessionRequestDto
    {
     
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
       
        public int Capacity { get; set; }
        public int Level { get; set; }

        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        
    }
}
