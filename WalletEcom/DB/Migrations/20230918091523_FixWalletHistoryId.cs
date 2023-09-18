using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletEcom.DB.Migrations
{
    public partial class FixWalletHistoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_wallet_history_tbl_wallet_wallet_id",
                table: "tbl_wallet_history");

            migrationBuilder.RenameColumn(
                name: "wallet_id",
                table: "tbl_wallet_history",
                newName: "WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_wallet_history_wallet_id",
                table: "tbl_wallet_history",
                newName: "IX_tbl_wallet_history_WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_wallet_history_tbl_wallet_WalletId",
                table: "tbl_wallet_history",
                column: "WalletId",
                principalTable: "tbl_wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_wallet_history_tbl_wallet_WalletId",
                table: "tbl_wallet_history");

            migrationBuilder.RenameColumn(
                name: "WalletId",
                table: "tbl_wallet_history",
                newName: "wallet_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_wallet_history_WalletId",
                table: "tbl_wallet_history",
                newName: "IX_tbl_wallet_history_wallet_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_wallet_history_tbl_wallet_wallet_id",
                table: "tbl_wallet_history",
                column: "wallet_id",
                principalTable: "tbl_wallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
