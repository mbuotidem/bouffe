using Microsoft.EntityFrameworkCore.Migrations;

namespace bouffe.Migrations
{
    public partial class OrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_PizzaTypes_PizzaTypeId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "Chickens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "IsPizzaOfTheWeek",
                table: "Pizzas");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "AMenuItem");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_PizzaTypeId",
                table: "AMenuItem",
                newName: "IX_AMenuItem_PizzaTypeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "AMenuItem",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "PizzaTypeId",
                table: "AMenuItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ChickenTypeId",
                table: "AMenuItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AMenuItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AMenuItem",
                table: "AMenuItem",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_AMenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "AMenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AMenuItem_ChickenTypeId",
                table: "AMenuItem",
                column: "ChickenTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_AMenuItem_ChickenTypes_ChickenTypeId",
                table: "AMenuItem",
                column: "ChickenTypeId",
                principalTable: "ChickenTypes",
                principalColumn: "ChickenTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AMenuItem_PizzaTypes_PizzaTypeId",
                table: "AMenuItem",
                column: "PizzaTypeId",
                principalTable: "PizzaTypes",
                principalColumn: "PizzaTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AMenuItem_ChickenTypes_ChickenTypeId",
                table: "AMenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_AMenuItem_PizzaTypes_PizzaTypeId",
                table: "AMenuItem");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AMenuItem",
                table: "AMenuItem");

            migrationBuilder.DropIndex(
                name: "IX_AMenuItem_ChickenTypeId",
                table: "AMenuItem");

            migrationBuilder.DropColumn(
                name: "ChickenTypeId",
                table: "AMenuItem");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AMenuItem");

            migrationBuilder.RenameTable(
                name: "AMenuItem",
                newName: "Pizzas");

            migrationBuilder.RenameIndex(
                name: "IX_AMenuItem_PizzaTypeId",
                table: "Pizzas",
                newName: "IX_Pizzas_PizzaTypeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Pizzas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<int>(
                name: "PizzaTypeId",
                table: "Pizzas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPizzaOfTheWeek",
                table: "Pizzas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Chickens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChickenTypeId = table.Column<int>(type: "int", nullable: false),
                    ImageThumbUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chickens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chickens_ChickenTypes_ChickenTypeId",
                        column: x => x.ChickenTypeId,
                        principalTable: "ChickenTypes",
                        principalColumn: "ChickenTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chickens_ChickenTypeId",
                table: "Chickens",
                column: "ChickenTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_PizzaTypes_PizzaTypeId",
                table: "Pizzas",
                column: "PizzaTypeId",
                principalTable: "PizzaTypes",
                principalColumn: "PizzaTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
