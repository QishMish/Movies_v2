using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.PersistanceDB.Migrations
{
    public partial class Addmoviestatusfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Movie",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Published",
                table: "Movie");
        }
    }
}
