using Microsoft.EntityFrameworkCore.Migrations;

namespace entrevista.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mail",
                table: "Persona",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(nullable: true),
                    descripcion = table.Column<string>(nullable: true),
                    modalidad = table.Column<int>(nullable: false),
                    fechas = table.Column<string>(nullable: true),
                    empresaId = table.Column<int>(nullable: false),
                    contactoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.id);
                    table.ForeignKey(
                        name: "FK_Curso_Persona_contactoId",
                        column: x => x.contactoId,
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curso_Empresa_empresaId",
                        column: x => x.empresaId,
                        principalTable: "Empresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curso_contactoId",
                table: "Curso",
                column: "contactoId");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_empresaId",
                table: "Curso",
                column: "empresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropColumn(
                name: "mail",
                table: "Persona");
        }
    }
}
