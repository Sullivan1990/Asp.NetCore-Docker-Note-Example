using Microsoft.EntityFrameworkCore.Migrations;

namespace aspDocker.Migrations
{
    public partial class UserNoteupdatewithseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ApplicationUserId);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Notes_User_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "User",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ApplicationUserId", "PasswordHash", "UserName" },
                values: new object[] { 1, "$2b$10$DgDEbtTUWmGl4l0Dei4fHeg6l1latha415M2Uld0eXrdzjDY63gTO", "Steve" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NoteId", "ApplicationUserId", "NoteBody", "NoteTitle" },
                values: new object[] { 1, 1, "The body of the first note", "An Example Note Title" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NoteId", "ApplicationUserId", "NoteBody", "NoteTitle" },
                values: new object[] { 2, 1, "The body of the second note", "Another Example Note Title" });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ApplicationUserId",
                table: "Notes",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
