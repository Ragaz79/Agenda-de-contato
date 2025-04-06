using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaContato.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GRUPOCONTATOS",
                columns: table => new
                {
                    GRUPO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GRUPO_NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPOCONTATOS", x => x.GRUPO_ID);
                });

            migrationBuilder.CreateTable(
                name: "TIPOCONTATOS",
                columns: table => new
                {
                    TIPO_COD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPO_NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPOCONTATOS", x => x.TIPO_COD);
                });

            migrationBuilder.CreateTable(
                name: "CONTATOS",
                columns: table => new
                {
                    CONTATO_COD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTATO_NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CONTATO_NUMERO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TIPO_COD = table.Column<int>(type: "int", nullable: true),
                    CONTATO_FAVORITO = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTATOS", x => x.CONTATO_COD);
                    table.ForeignKey(
                        name: "FK_CONTATOS_TIPOCONTATOS_TIPO_COD",
                        column: x => x.TIPO_COD,
                        principalTable: "TIPOCONTATOS",
                        principalColumn: "TIPO_COD");
                });

            migrationBuilder.CreateTable(
                name: "CONTATOSGRUPOS",
                columns: table => new
                {
                    CONT_GRUP_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTATO_ID = table.Column<int>(type: "int", nullable: false),
                    GRUPO_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTATOSGRUPOS", x => x.CONT_GRUP_ID);
                    table.ForeignKey(
                        name: "FK_CONTATOSGRUPOS_CONTATOS_CONTATO_ID",
                        column: x => x.CONTATO_ID,
                        principalTable: "CONTATOS",
                        principalColumn: "CONTATO_COD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CONTATOSGRUPOS_GRUPOCONTATOS_GRUPO_ID",
                        column: x => x.GRUPO_ID,
                        principalTable: "GRUPOCONTATOS",
                        principalColumn: "GRUPO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTATOS_TIPO_COD",
                table: "CONTATOS",
                column: "TIPO_COD");

            migrationBuilder.CreateIndex(
                name: "IX_CONTATOSGRUPOS_CONTATO_ID",
                table: "CONTATOSGRUPOS",
                column: "CONTATO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTATOSGRUPOS_GRUPO_ID",
                table: "CONTATOSGRUPOS",
                column: "GRUPO_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTATOSGRUPOS");

            migrationBuilder.DropTable(
                name: "CONTATOS");

            migrationBuilder.DropTable(
                name: "GRUPOCONTATOS");

            migrationBuilder.DropTable(
                name: "TIPOCONTATOS");
        }
    }
}
