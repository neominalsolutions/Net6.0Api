using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Articles.Infra.EF.Migrations
{
    public partial class CommentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentBy",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentBy",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Comment");
        }
    }
}
