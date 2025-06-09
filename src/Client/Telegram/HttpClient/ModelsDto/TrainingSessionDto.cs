
namespace DragonBoatHub.TelegramBot.DragonBot.HttpClient.ModelDto;

internal class TrainingSessionDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int AvailableSlots { get; set; }
}
