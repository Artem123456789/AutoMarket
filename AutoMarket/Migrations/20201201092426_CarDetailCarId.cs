using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMarket.Migrations
{
    public partial class CarDetailCarId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDetails_Cars_CarId",
                table: "CarDetails");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "CarDetails",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarDetails_Cars_CarId",
                table: "CarDetails",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDetails_Cars_CarId",
                table: "CarDetails");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "CarDetails",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDetails_Cars_CarId",
                table: "CarDetails",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
