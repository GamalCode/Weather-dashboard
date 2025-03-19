using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherDashboard.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFavoriteCityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FavoriteCity",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Humidity",
                table: "FavoriteCity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Temp",
                table: "FavoriteCity",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WindSpeed",
                table: "FavoriteCity",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FavoriteCity");

            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "FavoriteCity");

            migrationBuilder.DropColumn(
                name: "Temp",
                table: "FavoriteCity");

            migrationBuilder.DropColumn(
                name: "WindSpeed",
                table: "FavoriteCity");
        }
    }
}
