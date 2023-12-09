using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab_4.Migrations
{
    /// <inheritdoc />
    public partial class Initial_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "List<IAbstractItem>",
                columns: table => new
                {
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Containers_Ports_PortID",
                        column: x => x.PortID,
                        principalTable: "Ports",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    fuel = table.Column<double>(type: "float", nullable: false),
                    totalWeightCapacity = table.Column<int>(type: "int", nullable: false),
                    maxNumberOfAllContainers = table.Column<int>(type: "int", nullable: false),
                    maxNumberOfHeavyContainers = table.Column<int>(type: "int", nullable: false),
                    maxNumberOfRefrigeratedContainers = table.Column<int>(type: "int", nullable: false),
                    maxNumberOfLiquidContainers = table.Column<int>(type: "int", nullable: false),
                    fuelConsumptionPerKM = table.Column<double>(type: "float", nullable: false),
                    PortID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ships_Ports_ID",
                        column: x => x.ID,
                        principalTable: "Ports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ships_Ports_PortID",
                        column: x => x.PortID,
                        principalTable: "Ports",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SmallItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    weight = table.Column<int>(type: "int", nullable: false),
                    ContainerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SmallItem_Containers_ContainerID",
                        column: x => x.ContainerID,
                        principalTable: "Containers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Containers_PortID",
                table: "Containers",
                column: "PortID");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_PortID",
                table: "Ships",
                column: "PortID");

            migrationBuilder.CreateIndex(
                name: "IX_SmallItem_ContainerID",
                table: "SmallItem",
                column: "ContainerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "List<IAbstractItem>");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "SmallItem");

            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "Ports");
        }
    }
}
