using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTeploobmenApp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    H0 = table.Column<int>(type: "INTEGER", nullable: false),
                    D = table.Column<double>(type: "REAL", nullable: false),
                    T1 = table.Column<double>(type: "REAL", nullable: false),
                    T2 = table.Column<double>(type: "REAL", nullable: false),
                    Wr = table.Column<double>(type: "REAL", nullable: false),
                    Cr = table.Column<double>(type: "REAL", nullable: false),
                    Cm = table.Column<double>(type: "REAL", nullable: false),
                    Gm = table.Column<double>(type: "REAL", nullable: false),
                    Av = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Variants");
        }
    }
}
