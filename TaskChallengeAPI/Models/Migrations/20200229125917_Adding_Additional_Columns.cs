using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class Adding_Additional_Columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TaskEntities",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaskExecutionId",
                table: "TaskEntities",
                type: "nvarchar(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TaskEntities");

            migrationBuilder.DropColumn(
                name: "TaskExecutionId",
                table: "TaskEntities");
        }
    }
}
