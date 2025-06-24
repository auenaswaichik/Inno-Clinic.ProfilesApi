using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminDateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Profile_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Office_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorDateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorCareerStartYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Profile_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Specialization_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Office_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientDateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Profile_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DoctorCareerStartYear", "DoctorDateBirth", "DoctorFirstName", "DoctorLastName", "DoctorMiddleName", "Office_ID", "Profile_ID", "Specialization_ID" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pasha", "Swagovich", "Andreevich", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pasha", "Swagovich", "Andreevich", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8"), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pasha", "Swagovich", "Andreevich", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
