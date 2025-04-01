using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppMVCLCT.Migrations
{
    /// <inheritdoc />
    public partial class joindate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UsersModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "UsersModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "UsersModel");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "UsersModel");
        }
    }
}
