using Microsoft.EntityFrameworkCore.Migrations;

namespace Phd.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupervisorConlusion",
                table: "BRStudent",
                newName: "SupervisorConclusion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupervisorConclusion",
                table: "BRStudent",
                newName: "SupervisorConlusion");
        }
    }
}
