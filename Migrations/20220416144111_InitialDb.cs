using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTrackerApp.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskStatus",
                columns: table => new
                {
                    id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.id);
                    table.ForeignKey(
                        name: "FK_Section_User",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSection = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    idStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    laboriousness = table.Column<int>(type: "int", nullable: false),
                    periodExecution = table.Column<DateTime>(type: "datetime", nullable: false),
                    dateCompletion = table.Column<DateTime>(type: "datetime", nullable: true),
                    actualExecutionTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.id);
                    table.ForeignKey(
                        name: "FK_Task_Section",
                        column: x => x.idSection,
                        principalTable: "Section",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Task_TaskStatus",
                        column: x => x.idStatus,
                        principalTable: "TaskStatus",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PerformersList",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idTask = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformersList", x => x.id);
                    table.ForeignKey(
                        name: "FK_PerformersList_Task",
                        column: x => x.idTask,
                        principalTable: "Task",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PerformersList_User",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Subtask",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTask = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateRegister = table.Column<DateTime>(type: "date", nullable: false),
                    idStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    laboriousness = table.Column<int>(type: "int", nullable: false),
                    periodExecution = table.Column<DateTime>(type: "datetime", nullable: false),
                    dateCompletion = table.Column<DateTime>(type: "datetime", nullable: true),
                    actualExecutionTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtask", x => x.id);
                    table.ForeignKey(
                        name: "FK_Subtask_Task",
                        column: x => x.idTask,
                        principalTable: "Task",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Subtask_TaskStatus",
                        column: x => x.idStatus,
                        principalTable: "TaskStatus",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerformersList_idTask",
                table: "PerformersList",
                column: "idTask");

            migrationBuilder.CreateIndex(
                name: "IX_PerformersList_idUser",
                table: "PerformersList",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Section_idUser",
                table: "Section",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Subtask_idStatus",
                table: "Subtask",
                column: "idStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Subtask_idTask",
                table: "Subtask",
                column: "idTask");

            migrationBuilder.CreateIndex(
                name: "IX_Task_idSection",
                table: "Task",
                column: "idSection");

            migrationBuilder.CreateIndex(
                name: "IX_Task_idStatus",
                table: "Task",
                column: "idStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerformersList");

            migrationBuilder.DropTable(
                name: "Subtask");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "TaskStatus");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
