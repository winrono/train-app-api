using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WorkoutAppApi.Migrations
{
    public partial class relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                table: "Exercises",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_UserEntityId",
                table: "Exercises",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_UserEntityId",
                table: "Exercises",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_UserEntityId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_UserEntityId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Exercises");
        }
    }
}
