using Microsoft.EntityFrameworkCore.Migrations;

namespace NeedyBuddy.Migrations
{
    public partial class _directvaluesinservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceCategory_ServiceCategoryId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_AspNetUsers_UserId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_UserId",
                table: "Service");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Service",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ServiceCategoryId",
                table: "Service",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Service",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_ApplicationUserId",
                table: "Service",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_AspNetUsers_ApplicationUserId",
                table: "Service",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceCategory_ServiceCategoryId",
                table: "Service",
                column: "ServiceCategoryId",
                principalTable: "ServiceCategory",
                principalColumn: "ServiceCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_AspNetUsers_ApplicationUserId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceCategory_ServiceCategoryId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_ApplicationUserId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Service");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Service",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ServiceCategoryId",
                table: "Service",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_Service_UserId",
                table: "Service",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceCategory_ServiceCategoryId",
                table: "Service",
                column: "ServiceCategoryId",
                principalTable: "ServiceCategory",
                principalColumn: "ServiceCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_AspNetUsers_UserId",
                table: "Service",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
