using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeziRehberim.DataAccessLayer.Migrations
{
    public partial class second_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccount_AspNetUsers_AppUserID",
                table: "CustomerAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerAccount",
                table: "CustomerAccount");

            migrationBuilder.RenameTable(
                name: "CustomerAccount",
                newName: "CustomerAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAccount_AppUserID",
                table: "CustomerAccounts",
                newName: "IX_CustomerAccounts_AppUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerAccounts",
                table: "CustomerAccounts",
                column: "CustomerAccountID");

            migrationBuilder.CreateTable(
                name: "CustomerAccountProcesses",
                columns: table => new
                {
                    CustomerAccountProcessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProcessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccountProcesses", x => x.CustomerAccountProcessID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_AspNetUsers_AppUserID",
                table: "CustomerAccounts",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_AspNetUsers_AppUserID",
                table: "CustomerAccounts");

            migrationBuilder.DropTable(
                name: "CustomerAccountProcesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerAccounts",
                table: "CustomerAccounts");

            migrationBuilder.RenameTable(
                name: "CustomerAccounts",
                newName: "CustomerAccount");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAccounts_AppUserID",
                table: "CustomerAccount",
                newName: "IX_CustomerAccount_AppUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerAccount",
                table: "CustomerAccount",
                column: "CustomerAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccount_AspNetUsers_AppUserID",
                table: "CustomerAccount",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
