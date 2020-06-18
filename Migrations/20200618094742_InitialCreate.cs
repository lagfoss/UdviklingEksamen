using Microsoft.EntityFrameworkCore.Migrations;

namespace UdviklingEksamen.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(maxLength: 100, nullable: false),
                    Beskrivelse = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produkts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(maxLength: 100, nullable: false),
                    Beskrivelse = table.Column<string>(nullable: false),
                    Enhed = table.Column<string>(nullable: false),
                    AntalPak = table.Column<int>(nullable: false),
                    Pris = table.Column<int>(nullable: false),
                    KategoriId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produkts_Kategoris_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkts_KategoriId",
                table: "Produkts",
                column: "KategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produkts");

            migrationBuilder.DropTable(
                name: "Kategoris");
        }
    }
}
