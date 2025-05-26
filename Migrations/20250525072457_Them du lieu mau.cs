using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buoi5.Migrations
{
    /// <inheritdoc />
    public partial class Themdulieumau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Grade",
                columns: ["GradeId", "GradeName"],
                values: [1, "22DTHG8"]
            );
            migrationBuilder.InsertData(
                table: "Grade",
                columns: ["GradeId", "GradeName"],
                values: [2, "22DTHG7"]
            );
            migrationBuilder.InsertData(
                table: "Grade",
                columns: ["GradeId", "GradeName"],
                values: [3, "22DTHG6"]
            );

            //insert student
            migrationBuilder.InsertData(
                table: "Student",
                columns: ["StudentId", "FirstName", "LastName", "GradeId"],
                values: [1, "Canh", "Ngu", 1]
            );

            migrationBuilder.InsertData(
                table: "Student",
                columns: ["StudentId", "FirstName", "LastName", "GradeId"],
                values: [2, "Trong", "Ngu", 2]
            );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
