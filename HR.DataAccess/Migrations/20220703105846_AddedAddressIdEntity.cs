using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.DataAccess.Migrations
{
    public partial class AddedAddressIdEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "addressId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_addressId",
                table: "Employees",
                column: "addressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Addresses_addressId",
                table: "Employees",
                column: "addressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Addresses_addressId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_addressId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "addressId",
                table: "Employees");
        }
    }
}
