using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseApi.Migrations
{
    public partial class SystemErrorLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "systemErrorLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    error_messg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    error_source = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_systemErrorLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "systemErrorLogs");
        }
    }
}
