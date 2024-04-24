using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanHouseMVC.Migrations
{
    /// <inheritdoc />
    public partial class V41 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropIndex(
                name: "IX_TB_InfoContato_ClienteId",
                table: "TB_InfoContato");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "TB_InfoContato");

            migrationBuilder.AddColumn<int>(
                name: "InfoContatoId",
                table: "TB_Clientes",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Clientes_InfoContatoId",
                table: "TB_Clientes",
                column: "InfoContatoId");

            migrationBuilder.DropIndex(
                name: "IX_TB_Clientes_InfoContatoId",
                table: "TB_Clientes");

            migrationBuilder.DropColumn(
                name: "InfoContatoId",
                table: "TB_Clientes");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "TB_InfoContato",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_InfoContato_ClienteId",
                table: "TB_InfoContato",
                column: "ClienteId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
