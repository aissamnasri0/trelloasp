using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trelloAsp.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateInscription",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idprojet",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Projets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionPro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: true),
                    IdUtilisateurNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projets_AspNetUsers_IdUtilisateurNavigationId",
                        column: x => x.IdUtilisateurNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Listes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProjet = table.Column<int>(type: "int", nullable: true),
                    IdProjetNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listes_Projets_IdProjetNavigationId",
                        column: x => x.IdProjetNavigationId,
                        principalTable: "Projets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UtilisateurProjets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false),
                    IdProjet = table.Column<int>(type: "int", nullable: false),
                    IdProjetNavigationId = table.Column<int>(type: "int", nullable: true),
                    IdUtilisateurNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilisateurProjets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UtilisateurProjets_AspNetUsers_IdUtilisateurNavigationId",
                        column: x => x.IdUtilisateurNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UtilisateurProjets_Projets_IdProjetNavigationId",
                        column: x => x.IdProjetNavigationId,
                        principalTable: "Projets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cartes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdListe = table.Column<int>(type: "int", nullable: true),
                    IdListeNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartes_Listes_IdListeNavigationId",
                        column: x => x.IdListeNavigationId,
                        principalTable: "Listes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCarte = table.Column<int>(type: "int", nullable: true),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: true),
                    IdCarteNavigationId = table.Column<int>(type: "int", nullable: true),
                    IdUtilisateurNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentaires_AspNetUsers_IdUtilisateurNavigationId",
                        column: x => x.IdUtilisateurNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Commentaires_Cartes_IdCarteNavigationId",
                        column: x => x.IdCarteNavigationId,
                        principalTable: "Cartes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Etiquettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Couleur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCarte = table.Column<int>(type: "int", nullable: true),
                    IdCarteNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquettes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etiquettes_Cartes_IdCarteNavigationId",
                        column: x => x.IdCarteNavigationId,
                        principalTable: "Cartes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartes_IdListeNavigationId",
                table: "Cartes",
                column: "IdListeNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_IdCarteNavigationId",
                table: "Commentaires",
                column: "IdCarteNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_IdUtilisateurNavigationId",
                table: "Commentaires",
                column: "IdUtilisateurNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Etiquettes_IdCarteNavigationId",
                table: "Etiquettes",
                column: "IdCarteNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Listes_IdProjetNavigationId",
                table: "Listes",
                column: "IdProjetNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Projets_IdUtilisateurNavigationId",
                table: "Projets",
                column: "IdUtilisateurNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilisateurProjets_IdProjetNavigationId",
                table: "UtilisateurProjets",
                column: "IdProjetNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilisateurProjets_IdUtilisateurNavigationId",
                table: "UtilisateurProjets",
                column: "IdUtilisateurNavigationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "Etiquettes");

            migrationBuilder.DropTable(
                name: "UtilisateurProjets");

            migrationBuilder.DropTable(
                name: "Cartes");

            migrationBuilder.DropTable(
                name: "Listes");

            migrationBuilder.DropTable(
                name: "Projets");

            migrationBuilder.DropColumn(
                name: "DateInscription",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "idprojet",
                table: "AspNetUsers");
        }
    }
}
