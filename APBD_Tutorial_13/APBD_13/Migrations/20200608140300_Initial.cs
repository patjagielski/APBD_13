using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_13.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confectionary",
                columns: table => new
                {
                    IdConfectionary = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PricePerItem = table.Column<float>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionary", x => x.IdConfectionary);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    IdClient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAccepted = table.Column<string>(nullable: true),
                    DateFinished = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    IdClient = table.Column<int>(nullable: false),
                    IdEmployee = table.Column<int>(nullable: false),
                    OrderIdOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Order_Customer_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Customer",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Order_OrderIdOrder",
                        column: x => x.OrderIdOrder,
                        principalTable: "Order",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Confectionary_Order",
                columns: table => new
                {
                    IdConfection = table.Column<int>(nullable: false),
                    IdOrder = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Confectionary_OrderIdConfection = table.Column<int>(nullable: true),
                    Confectionary_OrderIdOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionary_Order", x => new { x.IdConfection, x.IdOrder });
                    table.ForeignKey(
                        name: "FK_Confectionary_Order_Confectionary_IdConfection",
                        column: x => x.IdConfection,
                        principalTable: "Confectionary",
                        principalColumn: "IdConfectionary",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Confectionary_Order_Order_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Order",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Confectionary_Order_Confectionary_Order_Confectionary_OrderIdConfection_Confectionary_OrderIdOrder",
                        columns: x => new { x.Confectionary_OrderIdConfection, x.Confectionary_OrderIdOrder },
                        principalTable: "Confectionary_Order",
                        principalColumns: new[] { "IdConfection", "IdOrder" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confectionary_Order_IdOrder",
                table: "Confectionary_Order",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Confectionary_Order_Confectionary_OrderIdConfection_Confectionary_OrderIdOrder",
                table: "Confectionary_Order",
                columns: new[] { "Confectionary_OrderIdConfection", "Confectionary_OrderIdOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdClient",
                table: "Order",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdEmployee",
                table: "Order",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderIdOrder",
                table: "Order",
                column: "OrderIdOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confectionary_Order");

            migrationBuilder.DropTable(
                name: "Confectionary");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
