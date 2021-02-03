using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Logic.Migrations
{
    public partial class InvoiceFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "Invoices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Invoices");
        }
    }
}
