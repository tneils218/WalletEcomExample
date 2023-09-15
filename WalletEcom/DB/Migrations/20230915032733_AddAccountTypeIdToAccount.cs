using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletEcom.DB.Migrations
{
    public partial class AddAccountTypeIdToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbl_account_type",
                columns: new[] { "Id", "account_type_name" },
                values: new object[] { 1, "normal" });

            migrationBuilder.InsertData(
                table: "tbl_account_type",
                columns: new[] { "Id", "account_type_name" },
                values: new object[] { 2, "premium" });

            migrationBuilder.InsertData(
                table: "tbl_account_type",
                columns: new[] { "Id", "account_type_name" },
                values: new object[] { 3, "vip" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_account_type",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_account_type",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_account_type",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
