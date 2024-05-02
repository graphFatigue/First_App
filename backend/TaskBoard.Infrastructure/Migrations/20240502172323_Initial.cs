using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TaskBoard.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "list_cards",
                columns: table => new
                {
                    list_cards_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_list_cards", x => x.list_cards_id);
                });

            migrationBuilder.CreateTable(
                name: "cards",
                columns: table => new
                {
                    card_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    due_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    priority = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    list_cards_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cards", x => x.card_id);
                    table.ForeignKey(
                        name: "FK_cards_list_cards_list_cards_id",
                        column: x => x.list_cards_id,
                        principalTable: "list_cards",
                        principalColumn: "list_cards_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "actions",
                columns: table => new
                {
                    action_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    message = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    action_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    card_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actions", x => x.action_id);
                    table.ForeignKey(
                        name: "FK_actions_cards_card_id",
                        column: x => x.card_id,
                        principalTable: "cards",
                        principalColumn: "card_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "list_cards",
                columns: new[] { "list_cards_id", "name" },
                values: new object[,]
                {
                    { 1, "Planned" },
                    { 2, "To Do" },
                    { 3, "In Progress" }
                });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "card_id", "description", "due_date", "list_cards_id", "name", "priority" },
                values: new object[,]
                {
                    { 1, "Necessary QA job for the website", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Do QA", "Medium" },
                    { 2, "The slider is displaying images with numbers 3,6,8 inappropriately", new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Fix the bug with the slider on the main page", "High" },
                    { 3, "The font must be Arial and the main color must be purple", new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Change the design of the navbar", "Low" },
                    { 4, "The font must be Arial and the main color must be purple", new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Change the design of the sidebar", "Low" },
                    { 5, "The description of products on the page 9 can't be changed", new DateTime(2024, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Fix the bug with the description of products", "High" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_actions_card_id",
                table: "actions",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "IX_cards_list_cards_id",
                table: "cards",
                column: "list_cards_id");

            migrationBuilder.CreateIndex(
                name: "IX_list_cards_name",
                table: "list_cards",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actions");

            migrationBuilder.DropTable(
                name: "cards");

            migrationBuilder.DropTable(
                name: "list_cards");
        }
    }
}
