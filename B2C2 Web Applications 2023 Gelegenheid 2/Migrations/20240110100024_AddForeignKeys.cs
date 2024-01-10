using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2C2_Web_Applications_2023_Gelegenheid_2.Migrations
{
    public partial class AddForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItems_CollectionNames_CollectionNameId",
                table: "CollectionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionNames_Admins_AdminId",
                table: "CollectionNames");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "CollectionNames",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CollectionNameId",
                table: "CollectionItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItems_CollectionNames_CollectionNameId",
                table: "CollectionItems",
                column: "CollectionNameId",
                principalTable: "CollectionNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionNames_Admins_AdminId",
                table: "CollectionNames",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionItems_CollectionNames_CollectionNameId",
                table: "CollectionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionNames_Admins_AdminId",
                table: "CollectionNames");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "CollectionNames",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CollectionNameId",
                table: "CollectionItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionItems_CollectionNames_CollectionNameId",
                table: "CollectionItems",
                column: "CollectionNameId",
                principalTable: "CollectionNames",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionNames_Admins_AdminId",
                table: "CollectionNames",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");
        }
    }
}
