using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace entrevista.Migrations
{
    public partial class s2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certificacion",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    certificacion = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    emision = table.Column<DateTime>(nullable: false),
                    vencimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificacion", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificacion");
        }
    }
}
