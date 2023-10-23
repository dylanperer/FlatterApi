using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class t3k2asdaa5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "helloGenderIdentityId",
                table: "Profiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_helloGenderIdentityId",
                table: "Profiles",
                column: "helloGenderIdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Genders_helloGenderIdentityId",
                table: "Profiles",
                column: "helloGenderIdentityId",
                principalTable: "Genders",
                principalColumn: "GenderIdentityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Genders_helloGenderIdentityId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_helloGenderIdentityId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "helloGenderIdentityId",
                table: "Profiles");
        }
    }
}
