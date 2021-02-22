using Microsoft.EntityFrameworkCore.Migrations;

namespace NewTreeTechApp.Migrations
{
    public partial class AlterAlarmeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarmes_Equipamentos_EquipamentoId",
                table: "Alarmes");

            migrationBuilder.DropColumn(
                name: "EquipamentoEquipId",
                table: "Alarmes");

            migrationBuilder.AlterColumn<int>(
                name: "EquipamentoId",
                table: "Alarmes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alarmes_Equipamentos_EquipamentoId",
                table: "Alarmes",
                column: "EquipamentoId",
                principalTable: "Equipamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarmes_Equipamentos_EquipamentoId",
                table: "Alarmes");

            migrationBuilder.AlterColumn<int>(
                name: "EquipamentoId",
                table: "Alarmes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EquipamentoEquipId",
                table: "Alarmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Alarmes_Equipamentos_EquipamentoId",
                table: "Alarmes",
                column: "EquipamentoId",
                principalTable: "Equipamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
