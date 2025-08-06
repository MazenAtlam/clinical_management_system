using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class state : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ccms");

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "ccms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMember",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    SSN = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMember", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MidName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                schema: "ccms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    floorNum = table.Column<int>(type: "int", nullable: false),
                    buildingNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rtype = table.Column<int>(type: "int", nullable: false),
                    rstatus = table.Column<int>(type: "int", nullable: false),
                    depId = table.Column<int>(type: "int", nullable: false),
                    departmentid = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.id);
                    table.ForeignKey(
                        name: "FK_Room_Department_departmentid",
                        column: x => x.departmentid,
                        principalSchema: "ccms",
                        principalTable: "Department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EType = table.Column<int>(type: "int", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MgrId = table.Column<int>(type: "int", nullable: true),
                    AdmId = table.Column<int>(type: "int", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Department_DeptId",
                        column: x => x.DeptId,
                        principalSchema: "ccms",
                        principalTable: "Department",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Employees_Employees_AdmId",
                        column: x => x.AdmId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Employees_MgrId",
                        column: x => x.MgrId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalDevice",
                schema: "ccms",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MDName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpirationHours = table.Column<long>(type: "bigint", nullable: false),
                    MDStatus = table.Column<int>(type: "int", nullable: false),
                    Roomid = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDevice", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_MedicalDevice_Room_Roomid",
                        column: x => x.Roomid,
                        principalSchema: "ccms",
                        principalTable: "Room",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    major = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiseaseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_Patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "ccms",
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PateintfFamilyJoin",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    FamilyMemberId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PateintfFamilyJoin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PateintfFamilyJoin_FamilyMember_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalSchema: "ccms",
                        principalTable: "FamilyMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PateintfFamilyJoin_Patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "ccms",
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scan",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScanType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScanTech = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Results = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scan_Patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "ccms",
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<double>(type: "float", nullable: false),
                    Perscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "ccms",
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "ccms",
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Room_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "ccms",
                        principalTable: "Room",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_DoctorId",
                schema: "ccms",
                table: "Book",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PatientId",
                schema: "ccms",
                table: "Book",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_RoomId",
                schema: "ccms",
                table: "Book",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AdmId",
                table: "Employees",
                column: "AdmId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeptId",
                table: "Employees",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MgrId",
                table: "Employees",
                column: "MgrId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalDevice_Roomid",
                schema: "ccms",
                table: "MedicalDevice",
                column: "Roomid");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_PatientId",
                schema: "ccms",
                table: "MedicalHistory",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PateintfFamilyJoin_FamilyMemberId",
                schema: "ccms",
                table: "PateintfFamilyJoin",
                column: "FamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_PateintfFamilyJoin_PatientId",
                schema: "ccms",
                table: "PateintfFamilyJoin",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_departmentid",
                schema: "ccms",
                table: "Room",
                column: "departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_Scan_PatientId",
                schema: "ccms",
                table: "Scan",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "MedicalDevice",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "MedicalHistory",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "PateintfFamilyJoin",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Scan",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Doctor",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Room",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "FamilyMember",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Patient",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
