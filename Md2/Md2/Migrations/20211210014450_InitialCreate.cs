using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Md2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Repos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResolvedReferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RepoId = table.Column<int>(type: "INTEGER", nullable: true),
                    SourceRelativePath = table.Column<string>(type: "TEXT", nullable: true),
                    TargetRelativePath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResolvedReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResolvedReferences_Repos_RepoId",
                        column: x => x.RepoId,
                        principalTable: "Repos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResolvedReferences_RepoId",
                table: "ResolvedReferences",
                column: "RepoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResolvedReferences");

            migrationBuilder.DropTable(
                name: "Repos");
        }
    }
}
