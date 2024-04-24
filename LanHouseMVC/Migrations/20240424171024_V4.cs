using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanHouseMVC.Migrations
{
    /// <inheritdoc />
    public partial class V4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Aplicativos");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "TB_Clientes");

            migrationBuilder.AddColumn<int>(
                name: "InfoContatoId",
                table: "TB_Clientes",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_InfoContato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_InfoContato", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Clientes_InfoContatoId",
                table: "TB_Clientes",
                column: "InfoContatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Clientes_TB_InfoContato_InfoContatoId",
                table: "TB_Clientes",
                column: "InfoContatoId",
                principalTable: "TB_InfoContato",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Clientes_TB_InfoContato_InfoContatoId",
                table: "TB_Clientes");

            migrationBuilder.DropTable(
                name: "TB_InfoContato");

            migrationBuilder.DropIndex(
                name: "IX_TB_Clientes_InfoContatoId",
                table: "TB_Clientes");

            migrationBuilder.DropColumn(
                name: "InfoContatoId",
                table: "TB_Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "TB_Clientes",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TB_Aplicativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ComputadorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Aplicativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Aplicativos_TB_Computadores_ComputadorId",
                        column: x => x.ComputadorId,
                        principalTable: "TB_Computadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Aplicativos_ComputadorId",
                table: "TB_Aplicativos",
                column: "ComputadorId");
        }
    }
}
