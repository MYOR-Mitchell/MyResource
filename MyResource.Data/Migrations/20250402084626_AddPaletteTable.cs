using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyResource.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPaletteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Palettes",
                columns: table => new
                {
                    PaletteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    BaseClr = table.Column<string>(type: "text", nullable: false),
                    SectionClr = table.Column<string>(type: "text", nullable: false),
                    TextClr = table.Column<string>(type: "text", nullable: false),
                    SecondaryTextClr = table.Column<string>(type: "text", nullable: false),
                    AccentClr = table.Column<string>(type: "text", nullable: false),
                    LineClr = table.Column<string>(type: "text", nullable: false),
                    HoverClr = table.Column<string>(type: "text", nullable: false),
                    ShadowClr = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palettes", x => x.PaletteId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Palettes");
        }
    }
}
