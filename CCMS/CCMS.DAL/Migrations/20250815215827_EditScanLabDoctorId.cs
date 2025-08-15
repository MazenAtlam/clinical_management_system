using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditScanLabDoctorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Address_Person_UID",
                schema: "ccms",
                table: "Person_Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_PhoneNumber_Person_UID",
                schema: "ccms",
                table: "Person_PhoneNumber");

            migrationBuilder.DropForeignKey(
                name: "FK_Scan_LabDoctor_LabDoctorUID",
                schema: "ccms",
                table: "Scan");

            migrationBuilder.DropIndex(
                name: "IX_Scan_LabDoctorUID",
                schema: "ccms",
                table: "Scan");

            migrationBuilder.DropColumn(
                name: "LabDoctorUID",
                schema: "ccms",
                table: "Scan");

            migrationBuilder.RenameColumn(
                name: "UID",
                schema: "ccms",
                table: "Person_PhoneNumber",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "UID",
                schema: "ccms",
                table: "Person_Address",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "ccms",
                table: "Department",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Perscription",
                schema: "ccms",
                table: "Book",
                newName: "Prescription");

            migrationBuilder.CreateIndex(
                name: "IX_Scan_LDID",
                schema: "ccms",
                table: "Scan",
                column: "LDID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Address_Person_PersonId",
                schema: "ccms",
                table: "Person_Address",
                column: "PersonId",
                principalSchema: "ccms",
                principalTable: "Person",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PhoneNumber_Person_PersonId",
                schema: "ccms",
                table: "Person_PhoneNumber",
                column: "PersonId",
                principalSchema: "ccms",
                principalTable: "Person",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scan_LabDoctor_LDID",
                schema: "ccms",
                table: "Scan",
                column: "LDID",
                principalSchema: "ccms",
                principalTable: "LabDoctor",
                principalColumn: "UID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Address_Person_PersonId",
                schema: "ccms",
                table: "Person_Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_PhoneNumber_Person_PersonId",
                schema: "ccms",
                table: "Person_PhoneNumber");

            migrationBuilder.DropForeignKey(
                name: "FK_Scan_LabDoctor_LDID",
                schema: "ccms",
                table: "Scan");

            migrationBuilder.DropIndex(
                name: "IX_Scan_LDID",
                schema: "ccms",
                table: "Scan");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "ccms",
                table: "Person_PhoneNumber",
                newName: "UID");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                schema: "ccms",
                table: "Person_Address",
                newName: "UID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "ccms",
                table: "Department",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Prescription",
                schema: "ccms",
                table: "Book",
                newName: "Perscription");

            migrationBuilder.AddColumn<int>(
                name: "LabDoctorUID",
                schema: "ccms",
                table: "Scan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Scan_LabDoctorUID",
                schema: "ccms",
                table: "Scan",
                column: "LabDoctorUID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Address_Person_UID",
                schema: "ccms",
                table: "Person_Address",
                column: "UID",
                principalSchema: "ccms",
                principalTable: "Person",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PhoneNumber_Person_UID",
                schema: "ccms",
                table: "Person_PhoneNumber",
                column: "UID",
                principalSchema: "ccms",
                principalTable: "Person",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scan_LabDoctor_LabDoctorUID",
                schema: "ccms",
                table: "Scan",
                column: "LabDoctorUID",
                principalSchema: "ccms",
                principalTable: "LabDoctor",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
