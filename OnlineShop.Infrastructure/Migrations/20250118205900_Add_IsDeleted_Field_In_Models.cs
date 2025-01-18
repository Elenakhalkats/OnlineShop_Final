using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_IsDeleted_Field_In_Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SalesLT");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "SalesLT",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "SalesLT",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "SalesLT",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "SalesLT",
                table: "ProductCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "SalesLT",
                table: "SalesOrderHeader",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "SalesLT",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "SalesLT",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "SalesLT",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "SalesLT",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "SalesLT",
                table: "SalesOrderHeader");
        }
    }
}
