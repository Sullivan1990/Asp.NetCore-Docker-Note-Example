using Microsoft.EntityFrameworkCore.Migrations;

namespace aspDocker.Migrations
{
    public partial class MoreseedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NoteId", "ApplicationUserId", "NoteBody", "NoteTitle" },
                values: new object[,]
                {
                    { 3, 1, "The body of the third note", "A Third Note Title" },
                    { 4, 1, "The body of the fourth note", "A fourth Example Note Title" },
                    { 5, 1, "The body of the fifth note", "An fifth Note Title" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ApplicationUserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2b$10$g.qXmK/K.jtmhl9qbVnOnOHYHoMfwNq/vifgyQry197Xcozx6T7Zm");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ApplicationUserId", "PasswordHash", "UserName" },
                values: new object[] { 2, "$2b$10$wwWSzgdvOh/mNgIAKRXK1.JvmJdglWC2uABFEFrAK4HkaB2gVid8m", "James" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ApplicationUserId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ApplicationUserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2b$10$DgDEbtTUWmGl4l0Dei4fHeg6l1latha415M2Uld0eXrdzjDY63gTO");
        }
    }
}
