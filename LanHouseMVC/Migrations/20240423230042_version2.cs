using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanHouseMVC.Migrations
{
    /// <inheritdoc />
    public partial class version2 : Migration
    {

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Computadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Computadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Aplicativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    AplicativoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Aplicativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Aplicativos_TB_Computadores_AplicativoId",
                        column: x => x.AplicativoId,
                        principalTable: "TB_Computadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_Perifericos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PerifericoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ComputadorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Marca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Perifericos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Perifericos_TB_Computadores_PerifericoId",
                        column: x => x.PerifericoId,
                        principalTable: "TB_Computadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Aplicativos_AplicativoId",
                table: "TB_Aplicativos",
                column: "AplicativoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Perifericos_PerifericoId",
                table: "TB_Perifericos",
                column: "PerifericoId");
        }
    }
}
