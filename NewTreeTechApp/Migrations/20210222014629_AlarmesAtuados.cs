using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewTreeTechApp.Migrations
{
    public partial class AlarmesAtuados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlarmesAtuados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeEntrada = table.Column<DateTime>(nullable: false),
                    DataDeSaida = table.Column<DateTime>(nullable: false),
                    StatusAlarme = table.Column<int>(nullable: false),
                    AlarmeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmesAtuados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlarmesAtuados_Alarmes_AlarmeId",
                        column: x => x.AlarmeId,
                        principalTable: "Alarmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlarmesAtuados_AlarmeId",
                table: "AlarmesAtuados",
                column: "AlarmeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlarmesAtuados");
        }
    }
}
