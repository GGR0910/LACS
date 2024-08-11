using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CollumNameCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sample_Users_AnalistyId",
                table: "Sample");

             migrationBuilder.RenameColumn(
                name: "AnalistyId",
                table: "Sample",
                newName: "AnalistId");

            migrationBuilder.RenameIndex(
                name: "IX_Sample_AnalistyId",
                table: "Sample",
                newName: "IX_Sample_AnalistId");
        
            migrationBuilder.AddForeignKey(
                name: "FK_Sample_Users_AnalistId",
                table: "Sample",
                column: "AnalistId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sample_Users_AnalistId",
                table: "Sample");

          migrationBuilder.RenameColumn(
                name: "AnalistId",
                table: "Sample",
                newName: "AnalistyId");

            migrationBuilder.RenameIndex(
                name: "IX_Sample_AnalistId",
                table: "Sample",
                newName: "IX_Sample_AnalistyId");
           
            migrationBuilder.AddForeignKey(
                name: "FK_Sample_Users_AnalistyId",
                table: "Sample",
                column: "AnalistyId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
