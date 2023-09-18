using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletEcom.DB.Migrations
{
    public partial class AddDataForActionFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbl_action",
                columns: new[] { "Id", "action_name" },
                values: new object[,]
                {
                    { 1, "Add money" },
                    { 2, "Transfer money" },
                    { 3, "Withdraw money" },
                    { 4, "Receive money" }
                });

            migrationBuilder.InsertData(
                table: "tbl_action_fee",
                columns: new[] { "Id", "action_fee_account_type", "action_fee_action_type", "fee" },
                values: new object[,]
                {
                    { 1, 1, 1, 0m },
                    { 2, 2, 1, 0m },
                    { 3, 3, 1, 0m },
                    { 4, 1, 2, 30m },
                    { 5, 2, 2, 20m },
                    { 6, 3, 2, 1m },
                    { 7, 1, 3, 25m },
                    { 8, 2, 3, 15m },
                    { 9, 3, 3, 5m },
                    { 10, 1, 4, 0m },
                    { 11, 2, 4, 0m },
                    { 12, 3, 4, 0m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_action_fee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_action_fee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_action_fee",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tbl_action_fee",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tbl_action_fee",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tbl_action_fee",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tbl_action_fee",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tbl_action_fee",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tbl_action_fee",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tbl_action_fee",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tbl_action_fee",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tbl_action_fee",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tbl_action",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_action",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_action",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tbl_action",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
