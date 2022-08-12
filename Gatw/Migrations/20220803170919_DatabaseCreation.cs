using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gatw.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gateways",
                columns: table => new
                {
                    GatewaeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPv4Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gateways", x => x.GatewaeyId);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AssociatedGatewaySerialNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceId);
                    table.ForeignKey(
                        name: "FK_Devices_Gateways_AssociatedGatewaySerialNumber",
                        column: x => x.AssociatedGatewaySerialNumber,
                        principalTable: "Gateways",
                        principalColumn: "GatewaeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gateways",
                columns: new[] { "GatewaeyId", "IPv4Address", "Name" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "10.8.77.120", "Gateway1" });

            migrationBuilder.InsertData(
                table: "Gateways",
                columns: new[] { "GatewaeyId", "IPv4Address", "Name" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "10.8.77.130", "Gateway2" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "DeviceId", "AssociatedGatewaySerialNumber", "DateCreated", "Status", "Vendor" },
                values: new object[] { 1, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Modem HP" });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "DeviceId", "AssociatedGatewaySerialNumber", "DateCreated", "Status", "Vendor" },
                values: new object[] { 2, new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Printer HP" });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_AssociatedGatewaySerialNumber",
                table: "Devices",
                column: "AssociatedGatewaySerialNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Gateways");
        }
    }
}
