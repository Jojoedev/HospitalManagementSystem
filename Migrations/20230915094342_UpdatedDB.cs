using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Migrations
{
    public partial class UpdatedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceLists");

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ExitDate",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "isNewPatient",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "onMedication",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Patients",
                newName: "PatientTypeId");

            migrationBuilder.CreateTable(
                name: "PatientTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PatientTypeId",
                table: "Patients",
                column: "PatientTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_PatientTypes_PatientTypeId",
                table: "Patients",
                column: "PatientTypeId",
                principalTable: "PatientTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_PatientTypes_PatientTypeId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "PatientTypes");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PatientTypeId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "PatientTypeId",
                table: "Patients",
                newName: "ServiceId");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExitDate",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isNewPatient",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "onMedication",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ServiceLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    ServiceOfferings = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceLists_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Sex" },
                values: new object[] { 1, "Female" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Sex" },
                values: new object[] { 2, "Male" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLists_PatientId",
                table: "ServiceLists",
                column: "PatientId");
        }
    }
}
