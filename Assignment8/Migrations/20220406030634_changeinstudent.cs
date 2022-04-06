using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment8.Migrations
{
    public partial class changeinstudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Teacher_ID",
                table: "Student",
                newName: "percentage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "percentage",
                table: "Student",
                newName: "Teacher_ID");
        }
    }
}
