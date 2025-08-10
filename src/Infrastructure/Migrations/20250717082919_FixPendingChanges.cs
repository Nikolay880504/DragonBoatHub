using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DragonBoatHub.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixPendingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "TrainingSessions");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "TrainingSessions",
                newName: "TrainingDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrainingDateTime",
                table: "TrainingSessions",
                newName: "Time");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "TrainingSessions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
