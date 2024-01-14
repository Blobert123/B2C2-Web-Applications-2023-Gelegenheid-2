using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2C2_Web_Applications_2023_Gelegenheid_2.Migrations
{
    public partial class CollectionItemExtraAtt3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CollectionItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CollectionItems_UserId",
                table: "CollectionItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItems_Users_UserId",
                table: "CollectionItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItems_Users_UserId",
                table: "CollectionItems");

            migrationBuilder.DropIndex(
                name: "IX_CollectionItems_UserId",
                table: "CollectionItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CollectionItems");
        }
    }
}
