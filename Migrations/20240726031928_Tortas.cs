using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doceria.Migrations
{
    /// <inheritdoc />
    public partial class Tortas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_TORTA",
                columns: table => new
                {
                    TordaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_TORTA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DS_TORTA = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    VL_PRECO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NM_TIPO = table.Column<int>(type: "int", nullable: false),
                    BL_VEGANA = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TORTA", x => x.TordaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TORTA");
        }
    }
}