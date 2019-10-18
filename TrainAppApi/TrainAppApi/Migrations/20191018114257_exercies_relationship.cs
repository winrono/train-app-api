using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WorkoutAppApi.Migrations
{
    public partial class exercies_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_UserEntityId",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "UserEntityId",
                table: "Exercises",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_UserEntityId",
                table: "Exercises",
                newName: "IX_Exercises_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_UserId",
                table: "Exercises",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_UserId",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Exercises",
                newName: "UserEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_UserId",
                table: "Exercises",
                newName: "IX_Exercises_UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_UserEntityId",
                table: "Exercises",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
