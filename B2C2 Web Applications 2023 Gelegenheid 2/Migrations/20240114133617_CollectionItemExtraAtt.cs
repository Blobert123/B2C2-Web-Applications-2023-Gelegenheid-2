using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2C2_Web_Applications_2023_Gelegenheid_2.Migrations
{
    public partial class CollectionItemExtraAtt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeOnline",
                table: "CollectionItems",
                newName: "ReleaseDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "CollectionItems",
                newName: "TimeOnline");
        }
    }
}
