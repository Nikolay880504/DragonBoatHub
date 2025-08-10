
namespace DragonBoatHub.Contracts
{
  public  class TrainingSessionRequestDto
    {  
        public DateTime TrainingDateTime { get; set; }    
        public int Capacity { get; set; }
        public int Level { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }     
    }
}
