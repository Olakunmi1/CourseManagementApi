using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MainCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Courses_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "DateOfBirth", "FirstName", "LastName", "MainCategory" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(1650, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Berry", "Griffin Beak  Eldricth", "Ships" },
                    { 2, new DateTimeOffset(new DateTime(1668, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Nancy", "Swashbuckler Rye", "Rum" },
                    { 3, new DateTimeOffset(new DateTime(1701, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Eli", "Ivory Bones Sweet", "Singing" },
                    { 4, new DateTimeOffset(new DateTime(1702, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Arnold", "The Unseen Stafford", "Singing" },
                    { 5, new DateTimeOffset(new DateTime(1690, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Seabury", "Toxic Reyson", "Maps" },
                    { 6, new DateTimeOffset(new DateTime(1723, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Rutherford", "Fearless Cloven", "General debauchery" },
                    { 7, new DateTimeOffset(new DateTime(1721, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Atherton", "Crow Ridley", "Rum" },
                    { 8, new DateTimeOffset(new DateTime(1969, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Huxford", "The Hawk Morris", "Maps" },
                    { 9, new DateTimeOffset(new DateTime(1972, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Dwennon", "Rigger Quye", "Maps" },
                    { 10, new DateTimeOffset(new DateTime(1982, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Rushford", "Subtle Asema", "Rum" },
                    { 11, new DateTimeOffset(new DateTime(1976, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Hagley", "Imposter Grendel", "Singing" },
                    { 12, new DateTimeOffset(new DateTime(1977, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Mabel", "Barnacle Grendel", "Maps" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "AuthorId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny", "Commandeering a Ship Without Getting Caught" },
                    { 2, 2, "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny.", "Overthrowing Mutiny" },
                    { 3, 3, "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny.", "Overthrowing Mutiny" },
                    { 4, 3, "Every good pirate loves rum, but it also has a tendency to get you into trouble.In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny", "Avoiding Brawls While Drinking as Much Rum as You Desire" },
                    { 5, 4, "In this course you'll learn how to sing all-time favourite pirate songs without sounding like In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny", "Singalong Pirate Hits" },
                    { 6, 4, "Every good pirate loves rum, but it also has a tendency to get you into trouble.In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny", "Avoiding Brawls While Drinking as Much Rum as You Desire" },
                    { 7, 9, "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny.In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny", "Overthrowing Mutiny" },
                    { 8, 10, "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny. In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny", " Mutiny" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AuthorId",
                table: "Courses",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
