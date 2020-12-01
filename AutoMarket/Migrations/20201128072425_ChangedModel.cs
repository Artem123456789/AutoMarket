using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMarket.Migrations
{
    public partial class ChangedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCarDetail");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "CarDetails",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarDetails_CarId",
                table: "CarDetails",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDetails_Cars_CarId",
                table: "CarDetails",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDetails_Cars_CarId",
                table: "CarDetails");

            migrationBuilder.DropIndex(
                name: "IX_CarDetails_CarId",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "CarDetails");

            migrationBuilder.CreateTable(
                name: "CarCarDetail",
                columns: table => new
                {
                    CarDetailsId = table.Column<int>(type: "INTEGER", nullable: false),
                    CarsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCarDetail", x => new { x.CarDetailsId, x.CarsId });
                    table.ForeignKey(
                        name: "FK_CarCarDetail_CarDetails_CarDetailsId",
                        column: x => x.CarDetailsId,
                        principalTable: "CarDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarCarDetail_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarCarDetail_CarsId",
                table: "CarCarDetail",
                column: "CarsId");
        }
    }
}
