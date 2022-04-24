using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTrackerApp.Migrations
{
    public partial class CorrectPeformersList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformersList_Task",
                table: "PerformersList");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformersList_User",
                table: "PerformersList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerformersList",
                table: "PerformersList");

            migrationBuilder.DropIndex(
                name: "IX_PerformersList_idTask",
                table: "PerformersList");

            migrationBuilder.DropIndex(
                name: "IX_PerformersList_idUser",
                table: "PerformersList");

            migrationBuilder.RenameTable(
                name: "PerformersList",
                newName: "PerformersLists");

            migrationBuilder.RenameColumn(
                name: "idUser",
                table: "PerformersLists",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "idTask",
                table: "PerformersLists",
                newName: "IdTask");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PerformersLists",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "PerformersList",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdTaskNavigationId",
                table: "PerformersLists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "IdUserNavigationId",
                table: "PerformersLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerformersLists",
                table: "PerformersLists",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PerformersLists_IdTaskNavigationId",
                table: "PerformersLists",
                column: "IdTaskNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformersLists_IdUserNavigationId",
                table: "PerformersLists",
                column: "IdUserNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformersLists_Task_IdTaskNavigationId",
                table: "PerformersLists",
                column: "IdTaskNavigationId",
                principalTable: "Task",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerformersLists_User_IdUserNavigationId",
                table: "PerformersLists",
                column: "IdUserNavigationId",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformersLists_Task_IdTaskNavigationId",
                table: "PerformersLists");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformersLists_User_IdUserNavigationId",
                table: "PerformersLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerformersLists",
                table: "PerformersLists");

            migrationBuilder.DropIndex(
                name: "IX_PerformersLists_IdTaskNavigationId",
                table: "PerformersLists");

            migrationBuilder.DropIndex(
                name: "IX_PerformersLists_IdUserNavigationId",
                table: "PerformersLists");

            migrationBuilder.DropColumn(
                name: "PerformersList",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "IdTaskNavigationId",
                table: "PerformersLists");

            migrationBuilder.DropColumn(
                name: "IdUserNavigationId",
                table: "PerformersLists");

            migrationBuilder.RenameTable(
                name: "PerformersLists",
                newName: "PerformersList");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "PerformersList",
                newName: "idUser");

            migrationBuilder.RenameColumn(
                name: "IdTask",
                table: "PerformersList",
                newName: "idTask");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PerformersList",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerformersList",
                table: "PerformersList",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_PerformersList_idTask",
                table: "PerformersList",
                column: "idTask");

            migrationBuilder.CreateIndex(
                name: "IX_PerformersList_idUser",
                table: "PerformersList",
                column: "idUser");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformersList_Task",
                table: "PerformersList",
                column: "idTask",
                principalTable: "Task",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformersList_User",
                table: "PerformersList",
                column: "idUser",
                principalTable: "User",
                principalColumn: "id");
        }
    }
}
