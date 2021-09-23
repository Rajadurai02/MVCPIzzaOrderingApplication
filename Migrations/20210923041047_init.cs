using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCPIzzaOrderingApplication.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PizzaDetails",
                columns: table => new
                {
                    PizzaNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    PizzaPrice = table.Column<int>(type: "int", nullable: true),
                    PizzaType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PizzaDet__E4FE0B3038219213", x => x.PizzaNumber);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ToppingNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToppingName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    ToppingPrice = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Toppings__0B581F426950E5DA", x => x.ToppingNumber);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginDetails",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMail = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    UserName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    UserPassword = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    UserAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    UserPhone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserLogi__1788CC4CF747A498", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<double>(type: "float", nullable: true),
                    DelivaryCharges = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK__Orders__UserId__3C69FB99",
                        column: x => x.UserId,
                        principalTable: "UserLoginDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ItemNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    PizzaNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__C28ACDB6EC11E389", x => x.ItemNumber);
                    table.ForeignKey(
                        name: "FK__OrderDeta__Order__3F466844",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__OrderDeta__Pizza__403A8C7D",
                        column: x => x.PizzaNumber,
                        principalTable: "PizzaDetails",
                        principalColumn: "PizzaNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemDetails",
                columns: table => new
                {
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    ToppingNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderIte__F23F4C4294D5BFFF", x => new { x.ItemNumber, x.ToppingNumber });
                    table.ForeignKey(
                        name: "FK__OrderItem__ItemN__4316F928",
                        column: x => x.ItemNumber,
                        principalTable: "OrderDetails",
                        principalColumn: "ItemNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__OrderItem__Toppi__440B1D61",
                        column: x => x.ToppingNumber,
                        principalTable: "Toppings",
                        principalColumn: "ToppingNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_PizzaNumber",
                table: "OrderDetails",
                column: "PizzaNumber");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetails_ToppingNumber",
                table: "OrderItemDetails",
                column: "ToppingNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemDetails");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PizzaDetails");

            migrationBuilder.DropTable(
                name: "UserLoginDetails");
        }
    }
}
