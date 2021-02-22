using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewTreeTechApp.Migrations
{
    public partial class AddAlarmesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alarmes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(maxLength: 300, nullable: false),
                    Classificacao = table.Column<int>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    EquipamentoId = table.Column<int>(nullable: true),
                    EquipamentoEquipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alarmes_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alarmes_EquipamentoId",
                table: "Alarmes",
                column: "EquipamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alarmes");
        }
    }
}
