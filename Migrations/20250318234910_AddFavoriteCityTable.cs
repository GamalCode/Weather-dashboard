using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherDashboard.Migrations
{
    /// <inheritdoc />
    public partial class AddFavoriteCityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteCities",
                table: "FavoriteCities");

            migrationBuilder.RenameTable(
                name: "FavoriteCities",
                newName: "FavoriteCity");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FavoriteCity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteCity",
                table: "FavoriteCity",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteCity",
                table: "FavoriteCity");

            migrationBuilder.RenameTable(
                name: "FavoriteCity",
                newName: "FavoriteCities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FavoriteCities",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteCities",
                table: "FavoriteCities",
                column: "Id");
        }
    }
}
