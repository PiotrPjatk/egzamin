using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EgzaminTrue.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    DueDate = table.Column<DateTime>(type: "date", nullable: false),
                    IdPatient = table.Column<int>(type: "integer", nullable: false),
                    IdDoctor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctors",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Patients",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medications",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "integer", nullable: false),
                    IdPrescription = table.Column<int>(type: "integer", nullable: false),
                    Dose = table.Column<int>(type: "integer", nullable: false),
                    Details = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription_Medications", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "FK_Prescription_Medications_Medications_IdMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medications",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Medications_Prescriptions_IdPrescription",
                        column: x => x.IdPrescription,
                        principalTable: "Prescriptions",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "John", "Doe" },
                    { 2, "janesmith@example.com", "Jane", "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Description A", "Medication A", "Type A" },
                    { 2, "Description B", "Medication B", "Type B" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Johnson" },
                    { 2, new DateTime(1992, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Linda", "Brown" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 2, 9, 10, 6, 337, DateTimeKind.Local).AddTicks(5931), new DateTime(2024, 3, 3, 9, 10, 6, 337, DateTimeKind.Local).AddTicks(5976), 1, 1 },
                    { 2, new DateTime(2024, 2, 2, 9, 10, 6, 337, DateTimeKind.Local).AddTicks(5983), new DateTime(2024, 3, 3, 9, 10, 6, 337, DateTimeKind.Local).AddTicks(5984), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medications",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "Take once daily", 1 },
                    { 2, 2, "Take twice daily", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medications_IdPrescription",
                table: "Prescription_Medications",
                column: "IdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdDoctor",
                table: "Prescriptions",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdPatient",
                table: "Prescriptions",
                column: "IdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medications");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
