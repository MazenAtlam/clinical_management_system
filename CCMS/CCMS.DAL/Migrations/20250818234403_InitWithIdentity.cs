using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitWithIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ccms");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMember",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Ssn = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                name: "WorkingSlot",
                schema: "ccms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<int>(type: "int", nullable: false),
                    day = table.Column<int>(type: "int", nullable: false),
                    startTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    endTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingSlot", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MidName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ssn = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                schema: "ccms",
                columns: table => new
                {
                    RNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    rtype = table.Column<int>(type: "int", nullable: false),
                    rstatus = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RNumber);
                    table.ForeignKey(
                        name: "FK_Room_Department_DeptId",
                        column: x => x.DeptId,
                        principalSchema: "ccms",
                        principalTable: "Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: true),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MgrId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AdmId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DeptId",
                        column: x => x.DeptId,
                        principalSchema: "ccms",
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Employee_AdmId",
                        column: x => x.AdmId,
                        principalSchema: "ccms",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Employee_MgrId",
                        column: x => x.MgrId,
                        principalSchema: "ccms",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Person_Id",
                        column: x => x.Id,
                        principalSchema: "ccms",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BloodType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Person_Id",
                        column: x => x.Id,
                        principalSchema: "ccms",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person_Address",
                schema: "ccms",
                columns: table => new
                {
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_Address", x => new { x.PersonId, x.address });
                    table.ForeignKey(
                        name: "FK_Person_Address_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "ccms",
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person_PhoneNumber",
                schema: "ccms",
                columns: table => new
                {
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_PhoneNumber", x => new { x.PersonId, x.Number });
                    table.ForeignKey(
                        name: "FK_Person_PhoneNumber_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "ccms",
                        principalTable: "Person",
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
                    rNumber = table.Column<string>(type: "nvarchar(6)", nullable: true),
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
                        name: "FK_MedicalDevice_Room_rNumber",
                        column: x => x.rNumber,
                        principalSchema: "ccms",
                        principalTable: "Room",
                        principalColumn: "RNumber");
                });

            migrationBuilder.CreateTable(
                name: "BiomedicalEngineer",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiomedicalEngineer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BiomedicalEngineer_Employee_Id",
                        column: x => x.Id,
                        principalSchema: "ccms",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    major = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Employee_Id",
                        column: x => x.Id,
                        principalSchema: "ccms",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeWorkingSlot",
                schema: "ccms",
                columns: table => new
                {
                    EmployeesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkingSlotsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWorkingSlot", x => new { x.EmployeesId, x.WorkingSlotsid });
                    table.ForeignKey(
                        name: "FK_EmployeeWorkingSlot_Employee_EmployeesId",
                        column: x => x.EmployeesId,
                        principalSchema: "ccms",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeWorkingSlot_WorkingSlot_WorkingSlotsid",
                        column: x => x.WorkingSlotsid,
                        principalSchema: "ccms",
                        principalTable: "WorkingSlot",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabDoctor",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabDoctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabDoctor_Employee_Id",
                        column: x => x.Id,
                        principalSchema: "ccms",
                        principalTable: "Employee",
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
                    IsAcceptable = table.Column<bool>(type: "bit", nullable: false),
                    DiseaseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Patient_FamilyMember",
                schema: "ccms",
                columns: table => new
                {
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FamilyMemberId = table.Column<int>(type: "int", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_FamilyMember", x => new { x.PatientId, x.FamilyMemberId });
                    table.ForeignKey(
                        name: "FK_Patient_FamilyMember_FamilyMember_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalSchema: "ccms",
                        principalTable: "FamilyMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_FamilyMember_Patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "ccms",
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalDevice_Room",
                schema: "ccms",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDevice_Room", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_MedicalDevice_Room_MedicalDevice_SerialNumber",
                        column: x => x.SerialNumber,
                        principalSchema: "ccms",
                        principalTable: "MedicalDevice",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalDevice_Room_Room_RNumber",
                        column: x => x.RNumber,
                        principalSchema: "ccms",
                        principalTable: "Room",
                        principalColumn: "RNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BiomedicalEngineerMedicalDevice",
                schema: "ccms",
                columns: table => new
                {
                    BiomedicalEngineersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MedicalDevicesSerialNumber = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiomedicalEngineerMedicalDevice", x => new { x.BiomedicalEngineersId, x.MedicalDevicesSerialNumber });
                    table.ForeignKey(
                        name: "FK_BiomedicalEngineerMedicalDevice_BiomedicalEngineer_BiomedicalEngineersId",
                        column: x => x.BiomedicalEngineersId,
                        principalSchema: "ccms",
                        principalTable: "BiomedicalEngineer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiomedicalEngineerMedicalDevice_MedicalDevice_MedicalDevicesSerialNumber",
                        column: x => x.MedicalDevicesSerialNumber,
                        principalSchema: "ccms",
                        principalTable: "MedicalDevice",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Prescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BookDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "ccms",
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Room_RNumber",
                        column: x => x.RNumber,
                        principalSchema: "ccms",
                        principalTable: "Room",
                        principalColumn: "RNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Scan",
                schema: "ccms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScanType = table.Column<int>(type: "int", nullable: false),
                    ScanTech = table.Column<int>(type: "int", nullable: false),
                    Results = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LDID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        name: "FK_Scan_LabDoctor_LDID",
                        column: x => x.LDID,
                        principalSchema: "ccms",
                        principalTable: "LabDoctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scan_Patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "ccms",
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BiomedicalEngineerMedicalDevice_MedicalDevicesSerialNumber",
                schema: "ccms",
                table: "BiomedicalEngineerMedicalDevice",
                column: "MedicalDevicesSerialNumber");

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
                name: "IX_Book_RNumber",
                schema: "ccms",
                table: "Book",
                column: "RNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AdmId",
                schema: "ccms",
                table: "Employee",
                column: "AdmId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DeptId",
                schema: "ccms",
                table: "Employee",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_MgrId",
                schema: "ccms",
                table: "Employee",
                column: "MgrId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkingSlot_WorkingSlotsid",
                schema: "ccms",
                table: "EmployeeWorkingSlot",
                column: "WorkingSlotsid");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalDevice_rNumber",
                schema: "ccms",
                table: "MedicalDevice",
                column: "rNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalDevice_Room_RNumber",
                schema: "ccms",
                table: "MedicalDevice_Room",
                column: "RNumber");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_PatientId",
                schema: "ccms",
                table: "MedicalHistory",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_FamilyMember_FamilyMemberId",
                schema: "ccms",
                table: "Patient_FamilyMember",
                column: "FamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_DeptId",
                schema: "ccms",
                table: "Room",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Scan_LDID",
                schema: "ccms",
                table: "Scan",
                column: "LDID");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BiomedicalEngineerMedicalDevice",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Book",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "EmployeeWorkingSlot",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "MedicalDevice_Room",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "MedicalHistory",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Patient_FamilyMember",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Person_Address",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Person_PhoneNumber",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Scan",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BiomedicalEngineer",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Doctor",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "WorkingSlot",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "MedicalDevice",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "FamilyMember",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "LabDoctor",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Patient",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Room",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "ccms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
