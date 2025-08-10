using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DragonBoatHub.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTrainingSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTrainingSessions",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "INTEGER", nullable: false),
                    SessionId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrainingSessions", x => new { x.SessionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserTrainingSessions_TrainingSessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "TrainingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTrainingSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingSessions_UserId",
                table: "UserTrainingSessions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTrainingSessions");
        }
    }
}
