using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkoButik_Client.Migrations
{
    /// <inheritdoc />
    public partial class FkCampaignId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Campaigns_CampaignId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CampaignId",
                table: "Products",
                newName: "FkCampaignId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CampaignId",
                table: "Products",
                newName: "IX_Products_FkCampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Campaigns_FkCampaignId",
                table: "Products",
                column: "FkCampaignId",
                principalTable: "Campaigns",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Campaigns_FkCampaignId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "FkCampaignId",
                table: "Products",
                newName: "CampaignId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_FkCampaignId",
                table: "Products",
                newName: "IX_Products_CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Campaigns_CampaignId",
                table: "Products",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
