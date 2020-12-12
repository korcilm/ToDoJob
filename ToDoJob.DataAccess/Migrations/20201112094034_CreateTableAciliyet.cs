using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoJob.DataAccess.Migrations
{
    public partial class CreateTableAciliyet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AciliyetId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Aciliyetler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aciliyetler", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_AciliyetId",
                table: "Jobs",
                column: "AciliyetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Aciliyetler_AciliyetId",
                table: "Jobs",
                column: "AciliyetId",
                principalTable: "Aciliyetler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Aciliyetler_AciliyetId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "Aciliyetler");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_AciliyetId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "AciliyetId",
                table: "Jobs");
        }
    }
}
