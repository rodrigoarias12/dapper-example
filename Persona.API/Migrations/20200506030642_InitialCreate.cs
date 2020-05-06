using Microsoft.EntityFrameworkCore.Migrations;

namespace Persona.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    IdDoc = table.Column<int>(nullable: false),
                    IdTipoContacto = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(fixedLength: true, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Contacto__C92D3B36AD16FC3D", x => new { x.IdDoc, x.IdTipoContacto });
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    IdDoc = table.Column<int>(nullable: false),
                    IdTipoDoc = table.Column<int>(nullable: true),
                    IdPais = table.Column<int>(nullable: true),
                    Sexo = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Edad = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(fixedLength: true, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Persona__5EACE01C794D0B1D", x => x.IdDoc);
                });

            migrationBuilder.CreateTable(
                name: "Relacion",
                columns: table => new
                {
                    IdDoc1 = table.Column<int>(nullable: false),
                    IdDoc2 = table.Column<int>(nullable: false),
                    IdRelacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Relacion__2E9D386BF7281ECC", x => new { x.IdDoc1, x.IdDoc2 });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Relacion");
        }
    }
}
