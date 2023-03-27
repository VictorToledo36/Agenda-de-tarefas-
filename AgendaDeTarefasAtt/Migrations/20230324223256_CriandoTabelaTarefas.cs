using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaDeTarefasAtt.Migrations
{
    public partial class CriandoTabelaTarefas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulotarefa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricaotarefa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<int>(type: "int", nullable: false),
                    Horainicio = table.Column<int>(type: "int", nullable: false),
                    Horafim = table.Column<int>(type: "int", nullable: false),
                    Prioridade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarefafinalizada = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}
