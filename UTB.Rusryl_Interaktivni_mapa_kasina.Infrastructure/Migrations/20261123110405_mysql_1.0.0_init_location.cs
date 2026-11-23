using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_100_init_location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CardType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CardTypeName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GameName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LocationKind",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LocationKindName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationKind", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LocationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LocationTypeName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CardNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpirationDate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CardTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_CardType_CardTypeId",
                        column: x => x.CardTypeId,
                        principalTable: "CardType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageSrc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Longitude = table.Column<double>(type: "double", nullable: false),
                    Latitude = table.Column<double>(type: "double", nullable: false),
                    LocationTypeId = table.Column<int>(type: "int", nullable: false),
                    LocationKindId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_LocationKind_LocationKindId",
                        column: x => x.LocationKindId,
                        principalTable: "LocationKind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Location_LocationType_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateAndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CardType",
                columns: new[] { "Id", "CardTypeName" },
                values: new object[,]
                {
                    { 1, "Visa" },
                    { 2, "Mastercard" },
                    { 3, "American Express" }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "GameName" },
                values: new object[] { 1, "poker" });

            migrationBuilder.InsertData(
                table: "LocationKind",
                columns: new[] { "Id", "LocationKindName" },
                values: new object[,]
                {
                    { 1, "obchod" },
                    { 2, "monument" },
                    { 3, "kasino" },
                    { 4, "knihovna" },
                    { 5, "hotel" }
                });

            migrationBuilder.InsertData(
                table: "LocationType",
                columns: new[] { "Id", "LocationTypeName" },
                values: new object[,]
                {
                    { 1, "location" },
                    { 2, "interactive" }
                });

            migrationBuilder.InsertData(
                table: "Card",
                columns: new[] { "Id", "CardNumber", "CardTypeId", "ExpirationDate", "SecurityCode" },
                values: new object[,]
                {
                    { 1, "371449635398431", 3, "03/30", "424" },
                    { 2, "4012000033330026", 1, "04/27", "264" },
                    { 3, "2223000048400011", 2, "10/28", "655" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Address", "ImageSrc", "Latitude", "LocationKindId", "LocationTypeId", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, "Karlovická 668/25", "/img/location/hotel-karlovicky-svet.jpg", -0.089999999999999997, 5, 1, 51.505000000000003, "Hotel Karlovický Svět" },
                    { 2, "Hrací 421/15", "/img/location/velke-vyhry.jpg", -0.089999999999999997, 3, 2, 52.505000000000003, "Velké Výhry" },
                    { 3, "Branická 422/31", "/img/location/grantova-brana.jpg", -0.089999999999999997, 2, 1, 50.505000000000003, "Grantova brána" },
                    { 4, "Univerzitní 402/44", "/img/location/svetnicka-narodni-knihovna.jpg", -0.58999999999999997, 4, 1, 51.505000000000003, "Světnická Národní Knihovna" },
                    { 5, "Obchodní 450/27", "/img/location/u-kvety.jpg", -0.58999999999999997, 1, 1, 50.505000000000003, "U Květy" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Content", "LocationId", "UserId" },
                values: new object[,]
                {
                    { 1, "Nejlepší kasino ve městě!", 2, 1 },
                    { 2, "Obrovský výběr knih, obsluha velmi příjemná. Vřele doporučuji tohle místo navštívit!", 4, 1 },
                    { 3, "Výběr obrovský, zboží domácí, zelenina čerstvá. Prostě super místo pro nákup.", 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_CardTypeId",
                table: "Card",
                column: "CardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_LocationId",
                table: "Comment",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_LocationKindId",
                table: "Location",
                column: "LocationKindId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_LocationTypeId",
                table: "Location",
                column: "LocationTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "CardType");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "LocationKind");

            migrationBuilder.DropTable(
                name: "LocationType");
        }
    }
}
