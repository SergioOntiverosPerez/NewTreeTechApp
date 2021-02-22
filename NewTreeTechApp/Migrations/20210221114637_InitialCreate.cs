using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewTreeTechApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDoEquipamento = table.Column<string>(maxLength: 255, nullable: false),
                    NumeroDeSerie = table.Column<string>(maxLength: 255, nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamentos");
        }
    }
}
