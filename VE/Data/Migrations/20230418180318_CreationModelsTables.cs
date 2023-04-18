using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VE.Data.Migrations
{
    public partial class CreationModelsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interventions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeIntervention = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interventions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reparation_Intervention",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeIntervention = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparation_Intervention", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voitures",
                columns: table => new
                {
                    VoituresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    DateVente = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrixAchat = table.Column<float>(type: "real", nullable: false),
                    PrixVente = table.Column<float>(type: "real", nullable: false),
                    VoituresExists = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.VoituresId);
                });

            migrationBuilder.CreateTable(
                name: "Reparations",
                columns: table => new
                {
                    ReparationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePriseEnCharge = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDelivrance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VoituresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparations", x => x.ReparationId);
                    table.ForeignKey(
                        name: "FK_Reparations_Voitures_VoituresId",
                        column: x => x.VoituresId,
                        principalTable: "Voitures",
                        principalColumn: "VoituresId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reparations_VoituresId",
                table: "Reparations",
                column: "VoituresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interventions");

            migrationBuilder.DropTable(
                name: "Reparation_Intervention");

            migrationBuilder.DropTable(
                name: "Reparations");

            migrationBuilder.DropTable(
                name: "Voitures");
        }
    }
}
