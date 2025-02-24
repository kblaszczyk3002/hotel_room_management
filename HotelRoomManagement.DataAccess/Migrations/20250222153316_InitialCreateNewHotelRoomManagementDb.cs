using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelRoomManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateNewHotelRoomManagementDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hrm");

            migrationBuilder.CreateTable(
                name: "HotelRoom",
                schema: "hrm",
                columns: table => new
                {
                    HotelRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoomType = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ReasonOfOccupation = table.Column<int>(type: "int", nullable: true),
                    ReasonOfMaintenance = table.Column<int>(type: "int", nullable: true),
                    AdditionalDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoom", x => x.HotelRoomId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_IsAvailable",
                schema: "hrm",
                table: "HotelRoom",
                column: "IsAvailable",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_Name",
                schema: "hrm",
                table: "HotelRoom",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_Size",
                schema: "hrm",
                table: "HotelRoom",
                column: "Size",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelRoom",
                schema: "hrm");
        }
    }
}
