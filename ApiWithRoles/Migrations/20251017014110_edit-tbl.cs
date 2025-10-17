using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWithRoles.Migrations
{
    /// <inheritdoc />
    public partial class edittbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateDate",
                table: "Warehouse",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Version",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateDate",
                table: "Version",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateDate",
                table: "Supplier",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateDate",
                table: "Product",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Model",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateDate",
                table: "Model",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "InventoryTransactionDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateDate",
                table: "InventoryTransactionDetail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "InventoryTransaction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateDate",
                table: "InventoryTransaction",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateDate",
                table: "Inventory",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "CustomerOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateDate",
                table: "CustomerOrder",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateDate",
                table: "Customer",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateDate",
                table: "Category",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreateDate",
                table: "Brand",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Version");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Version");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Model");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "InventoryTransactionDetail");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "InventoryTransactionDetail");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "InventoryTransaction");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "InventoryTransaction");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "CustomerOrder");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "CustomerOrder");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Brand");
        }
    }
}
