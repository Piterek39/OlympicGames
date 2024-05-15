using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    city_name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__city__3213E83F6A6B0D91", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    games_year = table.Column<int>(type: "int", nullable: true),
                    games_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    season = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__games__3213E83F15CE5477", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    medal_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__medal__3213E83F8DDD07AC", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "noc_region",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    noc = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    region_name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__noc_regi__3213E83F69C441D7", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    full_name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    gender = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    height = table.Column<int>(type: "int", nullable: true),
                    weight = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__person__3213E83FB1E5042F", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sport",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    sport_name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__sport__3213E83FFB827D10", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "games_city",
                columns: table => new
                {
                    games_id = table.Column<int>(type: "int", nullable: true),
                    city_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "fk_gci_city",
                        column: x => x.city_id,
                        principalTable: "city",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_gci_gam",
                        column: x => x.games_id,
                        principalTable: "games",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "games_competitor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    games_id = table.Column<int>(type: "int", nullable: true),
                    person_id = table.Column<int>(type: "int", nullable: true),
                    age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__games_co__3213E83F60C2888A", x => x.id);
                    table.ForeignKey(
                        name: "fk_gc_gam",
                        column: x => x.games_id,
                        principalTable: "games",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_gc_per",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "person_region",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int", nullable: true),
                    region_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "fk_per_per",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_per_reg",
                        column: x => x.region_id,
                        principalTable: "noc_region",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    sport_id = table.Column<int>(type: "int", nullable: true),
                    event_name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__event__3213E83F4E0F25C5", x => x.id);
                    table.ForeignKey(
                        name: "fk_ev_sp",
                        column: x => x.sport_id,
                        principalTable: "sport",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "competitor_event",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "int", nullable: true),
                    competitor_id = table.Column<int>(type: "int", nullable: true),
                    medal_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "fk_ce_com",
                        column: x => x.competitor_id,
                        principalTable: "games_competitor",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ce_ev",
                        column: x => x.event_id,
                        principalTable: "event",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ce_med",
                        column: x => x.medal_id,
                        principalTable: "medal",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_competitor_event_competitor_id",
                table: "competitor_event",
                column: "competitor_id");

            migrationBuilder.CreateIndex(
                name: "IX_competitor_event_event_id",
                table: "competitor_event",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_competitor_event_medal_id",
                table: "competitor_event",
                column: "medal_id");

            migrationBuilder.CreateIndex(
                name: "IX_event_sport_id",
                table: "event",
                column: "sport_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_city_city_id",
                table: "games_city",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_city_games_id",
                table: "games_city",
                column: "games_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_competitor_games_id",
                table: "games_competitor",
                column: "games_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_competitor_person_id",
                table: "games_competitor",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_region_person_id",
                table: "person_region",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_person_region_region_id",
                table: "person_region",
                column: "region_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "competitor_event");

            migrationBuilder.DropTable(
                name: "games_city");

            migrationBuilder.DropTable(
                name: "person_region");

            migrationBuilder.DropTable(
                name: "games_competitor");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "medal");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "noc_region");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "sport");
        }
    }
}
