using Microsoft.EntityFrameworkCore.Migrations;

namespace RealTimeMVCapp.Migrations
{
    public partial class realTimeInitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    materialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    materialYFlag = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.materialId);
                });

            migrationBuilder.CreateTable(
                name: "MaterialItems",
                columns: table => new
                {
                    materialItemsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    materialDescription = table.Column<string>(nullable: true),
                    materialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialItems", x => x.materialItemsId);
                    table.ForeignKey(
                        name: "FK_MaterialItems_Material_materialId",
                        column: x => x.materialId,
                        principalTable: "Material",
                        principalColumn: "materialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialItems_materialId",
                table: "MaterialItems",
                column: "materialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialItems");

            migrationBuilder.DropTable(
                name: "Material");
        }
    }
}
