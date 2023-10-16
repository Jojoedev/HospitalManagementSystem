using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Migrations
{
    public partial class UpdatedNullablePropnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Genders_GenderId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_PatientTypes_PatientTypeId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "PatientTypeId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Genders_GenderId",
                table: "Patients",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_PatientTypes_PatientTypeId",
                table: "Patients",
                column: "PatientTypeId",
                principalTable: "PatientTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Genders_GenderId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_PatientTypes_PatientTypeId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "PatientTypeId",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Genders_GenderId",
                table: "Patients",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_PatientTypes_PatientTypeId",
                table: "Patients",
                column: "PatientTypeId",
                principalTable: "PatientTypes",
                principalColumn: "Id");
        }
    }
}
