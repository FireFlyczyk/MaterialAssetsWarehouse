using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MaterialAssetsWarehouse.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group = table.Column<int>(type: "int", nullable: false),
                    Measurement = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PriceWithoutVAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "ContactPerson", "Group", "Measurement", "PriceWithoutVAT", "Quantity", "Status", "StorageLocation" },
                values: new object[,]
                {
                    { 1043, "Andrzej Zalewski", 0, 4, 40m, 10, "available", "Warsaw" },
                    { 2841, "Jarek Sannikov", 2, 1, 3259m, 100, "only 300 kg left", "Poznań" },
                    { 4324, "Andrzej Zalewski", 1, 2, 60m, 30, "available", "Piaseczno" },
                    { 4832, "Maria Ziobro", 1, 1, 249m, 3, "available", "Radom" },
                    { 5321, "Marek Kozłowksi", 3, 4, 65000m, 1, "available", "Warsaw" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
