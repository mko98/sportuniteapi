using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SportUnite.DAL.Migrations
{
    public partial class DevelopFinalMats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    SportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Availability = table.Column<bool>(nullable: false, defaultValue: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "SportAttribute",
                columns: table => new
                {
                    SportAttributeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Availability = table.Column<bool>(nullable: false, defaultValue: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NotUsable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportAttribute", x => x.SportAttributeId);
                });

            migrationBuilder.CreateTable(
                name: "SportComplex",
                columns: table => new
                {
                    SportComplexId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Availability = table.Column<bool>(nullable: false, defaultValue: true),
                    City = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportComplex", x => x.SportComplexId);
                });

            migrationBuilder.CreateTable(
                name: "SportSportAttribute",
                columns: table => new
                {
                    SportId = table.Column<int>(nullable: false),
                    SportAttributeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportSportAttribute", x => new { x.SportId, x.SportAttributeId });
                    table.ForeignKey(
                        name: "FK_SportSportAttribute_SportAttribute_SportAttributeId",
                        column: x => x.SportAttributeId,
                        principalTable: "SportAttribute",
                        principalColumn: "SportAttributeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportSportAttribute_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Availability = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(nullable: true),
                    SportComplexId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_SportComplex_SportComplexId",
                        column: x => x.SportComplexId,
                        principalTable: "SportComplex",
                        principalColumn: "SportComplexId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SportHall",
                columns: table => new
                {
                    SportHallId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Availability = table.Column<bool>(nullable: false, defaultValue: true),
                    MaxPerson = table.Column<int>(nullable: true),
                    MinPerson = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SportComplexId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportHall", x => x.SportHallId);
                    table.ForeignKey(
                        name: "FK_SportHall_SportComplex_SportComplexId",
                        column: x => x.SportComplexId,
                        principalTable: "SportComplex",
                        principalColumn: "SportComplexId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SportEvent",
                columns: table => new
                {
                    SportEventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Availability = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    SportHallId = table.Column<int>(nullable: true),
                    SportId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportEvent", x => x.SportEventId);
                    table.ForeignKey(
                        name: "FK_SportEvent_SportHall_SportHallId",
                        column: x => x.SportHallId,
                        principalTable: "SportHall",
                        principalColumn: "SportHallId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SportEvent_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SportComplexId",
                table: "Invoice",
                column: "SportComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_SportEvent_SportHallId",
                table: "SportEvent",
                column: "SportHallId");

            migrationBuilder.CreateIndex(
                name: "IX_SportEvent_SportId",
                table: "SportEvent",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_SportHall_SportComplexId",
                table: "SportHall",
                column: "SportComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_SportSportAttribute_SportAttributeId",
                table: "SportSportAttribute",
                column: "SportAttributeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "SportEvent");

            migrationBuilder.DropTable(
                name: "SportSportAttribute");

            migrationBuilder.DropTable(
                name: "SportHall");

            migrationBuilder.DropTable(
                name: "SportAttribute");

            migrationBuilder.DropTable(
                name: "Sport");

            migrationBuilder.DropTable(
                name: "SportComplex");
        }
    }
}
