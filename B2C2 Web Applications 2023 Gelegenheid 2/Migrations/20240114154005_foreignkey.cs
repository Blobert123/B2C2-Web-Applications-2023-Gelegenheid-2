using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2C2_Web_Applications_2023_Gelegenheid_2.Migrations
{
    public partial class foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "CollectionItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollectionItems_UserId1",
                table: "CollectionItems",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItems_Users_UserId1",
                table: "CollectionItems",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItems_Users_UserId1",
                table: "CollectionItems");

            migrationBuilder.DropIndex(
                name: "IX_CollectionItems_UserId1",
                table: "CollectionItems");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "CollectionItems");
        }
    }
}
