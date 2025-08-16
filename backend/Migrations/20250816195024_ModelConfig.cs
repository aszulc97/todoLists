using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class ModelConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItems_Lists_ListRecordId",
                table: "ListItems");

            migrationBuilder.DropIndex(
                name: "IX_ListItems_ListRecordId",
                table: "ListItems");

            migrationBuilder.DropColumn(
                name: "ListRecordId",
                table: "ListItems");

            migrationBuilder.CreateIndex(
                name: "IX_ListItems_ListId",
                table: "ListItems",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListItems_Lists_ListId",
                table: "ListItems",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItems_Lists_ListId",
                table: "ListItems");

            migrationBuilder.DropIndex(
                name: "IX_ListItems_ListId",
                table: "ListItems");

            migrationBuilder.AddColumn<Guid>(
                name: "ListRecordId",
                table: "ListItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListItems_ListRecordId",
                table: "ListItems",
                column: "ListRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListItems_Lists_ListRecordId",
                table: "ListItems",
                column: "ListRecordId",
                principalTable: "Lists",
                principalColumn: "Id");
        }
    }
}
