using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfectMatch.API.Migrations
{
    /// <inheritdoc />
    public partial class PerfectMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    age = table.Column<int>(type: "int", nullable: false),
                    Ubication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SexualOrientation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CivilState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalPhotos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkNetwors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Nacionality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
