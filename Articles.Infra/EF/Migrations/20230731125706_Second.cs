using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Articles.Infra.EF.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Makale_ArticleId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Makale",
                table: "Makale");

            migrationBuilder.RenameTable(
                name: "Makale",
                newName: "Articles");

            migrationBuilder.RenameColumn(
                name: "Aciklama",
                table: "Articles",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_Makale_Name",
                table: "Articles",
                newName: "IX_Articles_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Articles_ArticleId",
                table: "Comment",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Articles_ArticleId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "Makale");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Makale",
                newName: "Aciklama");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_Name",
                table: "Makale",
                newName: "IX_Makale_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Makale",
                table: "Makale",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Makale_ArticleId",
                table: "Comment",
                column: "ArticleId",
                principalTable: "Makale",
                principalColumn: "Id");
        }
    }
}
