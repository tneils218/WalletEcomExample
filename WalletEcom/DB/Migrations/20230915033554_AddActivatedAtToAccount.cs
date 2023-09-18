using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletEcom.DB.Migrations
{
    public partial class AddActivatedAtToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "activated_at",
                table: "tbl_account",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "activated_at",
                table: "tbl_account");
        }
    }
}
