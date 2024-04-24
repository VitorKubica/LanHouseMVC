using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanHouseMVC.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ComputadorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ClienteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataReserva = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Reserva_TB_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TB_Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Reserva_TB_Computadores_ComputadorId",
                        column: x => x.ComputadorId,
                        principalTable: "TB_Computadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Reserva_ClienteId",
                table: "TB_Reserva",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Reserva_ComputadorId",
                table: "TB_Reserva",
                column: "ComputadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Reserva");
        }
    }
}
