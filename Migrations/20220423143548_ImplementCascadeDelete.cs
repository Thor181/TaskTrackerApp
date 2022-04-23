using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTrackerApp.Migrations
{
    public partial class ImplementCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_User",
                table: "Section");

            migrationBuilder.AlterColumn<long>(
                name: "idSection",
                table: "Task",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "idTask",
                table: "Subtask",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_User",
                table: "Section",
                column: "idUser",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_User",
                table: "Section");

            migrationBuilder.AlterColumn<long>(
                name: "idSection",
                table: "Task",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "idTask",
                table: "Subtask",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_User",
                table: "Section",
                column: "idUser",
                principalTable: "User",
                principalColumn: "id");
        }
    }
}
