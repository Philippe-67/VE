using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VE.Data.Migrations
{
    public partial class InterRepar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InterventionId",
                table: "Reparation_Intervention",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReparationId",
                table: "Reparation_Intervention",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "Interventions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Reparation_Intervention_InterventionId",
                table: "Reparation_Intervention",
                column: "InterventionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reparation_Intervention_ReparationId",
                table: "Reparation_Intervention",
                column: "ReparationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reparation_Intervention_Interventions_InterventionId",
                table: "Reparation_Intervention",
                column: "InterventionId",
                principalTable: "Interventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reparation_Intervention_Reparations_ReparationId",
                table: "Reparation_Intervention",
                column: "ReparationId",
                principalTable: "Reparations",
                principalColumn: "ReparationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reparation_Intervention_Interventions_InterventionId",
                table: "Reparation_Intervention");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparation_Intervention_Reparations_ReparationId",
                table: "Reparation_Intervention");

            migrationBuilder.DropIndex(
                name: "IX_Reparation_Intervention_InterventionId",
                table: "Reparation_Intervention");

            migrationBuilder.DropIndex(
                name: "IX_Reparation_Intervention_ReparationId",
                table: "Reparation_Intervention");

            migrationBuilder.DropColumn(
                name: "InterventionId",
                table: "Reparation_Intervention");

            migrationBuilder.DropColumn(
                name: "ReparationId",
                table: "Reparation_Intervention");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Interventions");
        }
    }
}
