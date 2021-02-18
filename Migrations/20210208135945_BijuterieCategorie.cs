using Microsoft.EntityFrameworkCore.Migrations;

namespace Bradea_Simona_AplicatieWeb.Migrations
{
    public partial class BijuterieCategorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Bijuterie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieNume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientNume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BijuterieCategorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BijuterieID = table.Column<int>(nullable: false),
                    CategorieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BijuterieCategorie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BijuterieCategorie_Bijuterie_BijuterieID",
                        column: x => x.BijuterieID,
                        principalTable: "Bijuterie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BijuterieCategorie_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bijuterie_ClientID",
                table: "Bijuterie",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_BijuterieCategorie_BijuterieID",
                table: "BijuterieCategorie",
                column: "BijuterieID");

            migrationBuilder.CreateIndex(
                name: "IX_BijuterieCategorie_CategorieID",
                table: "BijuterieCategorie",
                column: "CategorieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bijuterie_Client_ClientID",
                table: "Bijuterie",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bijuterie_Client_ClientID",
                table: "Bijuterie");

            migrationBuilder.DropTable(
                name: "BijuterieCategorie");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Bijuterie_ClientID",
                table: "Bijuterie");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Bijuterie");
        }
    }
}
