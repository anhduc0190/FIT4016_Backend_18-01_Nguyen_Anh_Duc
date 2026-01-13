using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Principal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Address", "CreatedAt", "Name", "Principal", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Cambridge, MA", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "Harvard University", "John Smith", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Stanford, CA", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "Stanford University", "Mary Johnson", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Cambridge, MA", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "MIT", "Robert Brown", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Oxford, UK", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "Oxford University", "Emily Davis", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Cambridge, UK", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "Cambridge University", "Michael Wilson", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "New Haven, CT", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "Yale University", "Sarah Miller", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Princeton, NJ", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "Princeton University", "David Garcia", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "New York, NY", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "Columbia University", "Jennifer Martinez", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Berkeley, CA", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "UC Berkeley", "James Anderson", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Pasadena, CA", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "Caltech", "Patricia Taylor", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "Phone", "SchoolId", "StudentId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "alice.walker@email.com", "Alice Walker", "1234567890", 1, "STU001", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "bob.martin@email.com", "Bob Martin", "2345678901", 1, "STU002", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "carol.white@email.com", "Carol White", "3456789012", 2, "STU003", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "daniel.harris@email.com", "Daniel Harris", "4567890123", 2, "STU004", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "emma.clark@email.com", "Emma Clark", "5678901234", 3, "STU005", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "frank.lewis@email.com", "Frank Lewis", "6789012345", 3, "STU006", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "grace.lee@email.com", "Grace Lee", "7890123456", 4, "STU007", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "henry.king@email.com", "Henry King", "8901234567", 4, "STU008", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "iris.moore@email.com", "Iris Moore", "9012345678", 5, "STU009", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "jack.scott@email.com", "Jack Scott", "1122334455", 5, "STU010", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "karen.young@email.com", "Karen Young", "2233445566", 6, "STU011", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "leo.allen@email.com", "Leo Allen", "3344556677", 6, "STU012", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "mia.hall@email.com", "Mia Hall", "4455667788", 7, "STU013", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "noah.adams@email.com", "Noah Adams", "5566778899", 7, "STU014", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "olivia.baker@email.com", "Olivia Baker", "6677889900", 8, "STU015", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "paul.carter@email.com", "Paul Carter", "7788990011", 8, "STU016", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "quinn.nelson@email.com", "Quinn Nelson", "8899001122", 9, "STU017", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "rachel.green@email.com", "Rachel Green", "9900112233", 9, "STU018", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "sam.turner@email.com", "Sam Turner", "1011121314", 10, "STU019", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), "tina.phillips@email.com", "Tina Phillips", "1112131415", 10, "STU020", new DateTime(2026, 1, 13, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schools_Name",
                table: "Schools",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Email",
                table: "Students",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentId",
                table: "Students",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
