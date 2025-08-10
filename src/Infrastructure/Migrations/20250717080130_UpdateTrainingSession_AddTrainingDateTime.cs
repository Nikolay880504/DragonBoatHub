using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DragonBoatHub.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrainingSession_AddTrainingDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TrainingDateTime",
                table: "TrainingSessions",
                type: "TEXT",
                nullable: false,
                defaultValue: DateTime.UtcNow);

            migrationBuilder.DropColumn(name: "Date", table: "TrainingSessions");
            migrationBuilder.DropColumn(name: "Time", table: "TrainingSessions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TrainingSessions",
                type: "TEXT",
                nullable: false,
                defaultValue: DateTime.UtcNow);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "TrainingSessions",
                type: "TEXT",
                nullable: false,
                defaultValue: TimeSpan.Zero);

            migrationBuilder.DropColumn(name: "TrainingDateTime", table: "TrainingSessions");
        }

    }
}
