using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WorkoutAppApi.Migrations
{
    public partial class userId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_UserId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_UserId",
                table: "Exercises");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Exercises",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Exercises",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_UserId1",
                table: "Exercises",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_UserId1",
                table: "Exercises",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_UserId1",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_UserId1",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Exercises");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Exercises",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_UserId",
                table: "Exercises",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_UserId",
                table: "Exercises",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
