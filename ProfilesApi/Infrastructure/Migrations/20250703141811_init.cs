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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CareerStartYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecializationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "CareerStartYear", "DateBirth", "FirstName", "LastName", "OfficeId", "ProfileId", "SpecializationId" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pasha", "Swagovich", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pasha", "Swagovich", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8"), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pasha", "Swagovich", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateBirth", "DeletedAt", "FirstName", "IsDeleted", "LastName", "ProfileId" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa1"), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ilia", false, "Kustovich", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa2"), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ilia", false, "Kustovich", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa3"), new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ilia", false, "Kustovich", new Guid("00000000-0000-0000-0000-000000000000") }
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
