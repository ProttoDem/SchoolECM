﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Identity.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTeachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardHolderName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CardType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Expiration",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecurityNumber",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTeacher",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsTeacher",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "CardHolderName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CardType",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Expiration",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecurityNumber",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
