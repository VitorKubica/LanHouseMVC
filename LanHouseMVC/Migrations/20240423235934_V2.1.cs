using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanHouseMVC.Migrations
{
    /// <inheritdoc />
    public partial class V21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Aplicativos");

            migrationBuilder.DropTable(
                name: "TB_Perifericos");

            migrationBuilder.DropTable(
                name: "TB_Computadores");

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
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ComputadorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TB_Perifericos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Marca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ComputadorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Perifericos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Perifericos_TB_Computadores_ComputadorId",
                        column: x => x.ComputadorId,
                        principalTable: "TB_Computadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Aplicativos_ComputadorId",
                table: "TB_Aplicativos",
                column: "ComputadorId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Perifericos_ComputadorId",
                table: "TB_Perifericos",
                column: "ComputadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
