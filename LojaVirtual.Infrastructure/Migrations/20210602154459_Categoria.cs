using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Infrastructure.Migrations
{
    public partial class Categoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Categorias",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                   .Annotation("SqlServer:Identity", "1, 1"),
                   DataCadastro = table.Column<DateTime>(nullable: false),
                   Nome = table.Column<string>(nullable: true),
                   Slug = table.Column<string>(nullable: true),
                   CategoriaPaiId = table.Column<int>(nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Categorias", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Categorias_Categorias_CategoriaPaiId",
                       column: x => x.CategoriaPaiId,
                       principalTable: "Categorias",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Restrict);
               });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_CategoriaPaiId",
                table: "Categorias",
                column: "CategoriaPaiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CategoriaPaiId",
                table: "Categorias",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Categorias",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}