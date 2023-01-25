using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HBYS.Data.Migrations
{
    /// <inheritdoc />
    public partial class telToPhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tel",
                table: "Patients",
                newName: "Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Patients",
                newName: "Tel");
        }
    }
}
