using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Phd.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryAcademicDegree",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ValueRus = table.Column<string>(nullable: true),
                    ValueKaz = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    ExtraString1 = table.Column<string>(nullable: true),
                    ExtraString2 = table.Column<string>(nullable: true),
                    ExtraInt1 = table.Column<int>(nullable: true),
                    ExtraDouble1 = table.Column<double>(nullable: true),
                    ExtaDateTime1 = table.Column<DateTime>(nullable: true),
                    ExtraBool1 = table.Column<bool>(nullable: false),
                    ExtraBool3 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryAcademicDegree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryStatusAvailability",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ValueRus = table.Column<string>(nullable: true),
                    ValueKaz = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    ExtraString1 = table.Column<string>(nullable: true),
                    ExtraString2 = table.Column<string>(nullable: true),
                    ExtraInt1 = table.Column<int>(nullable: true),
                    ExtraDouble1 = table.Column<double>(nullable: true),
                    ExtaDateTime1 = table.Column<DateTime>(nullable: true),
                    ExtraBool1 = table.Column<bool>(nullable: false),
                    ExtraBool3 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryStatusAvailability", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryStatusConclusion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ValueRus = table.Column<string>(nullable: true),
                    ValueKaz = table.Column<string>(nullable: true),
                    ValueEng = table.Column<string>(nullable: true),
                    ExtraString1 = table.Column<string>(nullable: true),
                    ExtraString2 = table.Column<string>(nullable: true),
                    ExtraInt1 = table.Column<int>(nullable: true),
                    ExtraDouble1 = table.Column<double>(nullable: true),
                    ExtaDateTime1 = table.Column<DateTime>(nullable: true),
                    ExtraBool1 = table.Column<bool>(nullable: false),
                    ExtraBool3 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryStatusConclusion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryStudyYear",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true),
                    ExtraString1 = table.Column<string>(nullable: true),
                    ExtraString2 = table.Column<string>(nullable: true),
                    ExtraInt1 = table.Column<int>(nullable: true),
                    ExtraDouble1 = table.Column<double>(nullable: true),
                    ExtaDateTime1 = table.Column<DateTime>(nullable: true),
                    ExtraBool1 = table.Column<bool>(nullable: false),
                    ExtraBool3 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryStudyYear", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ExtraString1 = table.Column<string>(nullable: true),
                    ExtraString2 = table.Column<string>(nullable: true),
                    ExtraInt1 = table.Column<int>(nullable: true),
                    ExtraDouble1 = table.Column<double>(nullable: true),
                    ExtaDateTime1 = table.Column<DateTime>(nullable: true),
                    ExtraBool1 = table.Column<bool>(nullable: false),
                    ExtraBool3 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradesTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvegrageGrade = table.Column<double>(nullable: true),
                    Gpa = table.Column<double>(nullable: true),
                    LetterGrade = table.Column<string>(nullable: true),
                    TraditionalGradeRus = table.Column<string>(nullable: true),
                    TraditionalGradeKaz = table.Column<string>(nullable: true),
                    TraditionalGradeEng = table.Column<string>(nullable: true),
                    ExtraString1 = table.Column<string>(nullable: true),
                    ExtraString2 = table.Column<string>(nullable: true),
                    ExtraInt1 = table.Column<int>(nullable: true),
                    ExtraDouble1 = table.Column<double>(nullable: true),
                    ExtaDateTime1 = table.Column<DateTime>(nullable: true),
                    ExtraBool1 = table.Column<bool>(nullable: false),
                    ExtraBool3 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradesTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentDocType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ExtraString1 = table.Column<string>(nullable: true),
                    ExtraString2 = table.Column<string>(nullable: true),
                    ExtraInt1 = table.Column<int>(nullable: true),
                    ExtraDouble1 = table.Column<double>(nullable: true),
                    ExtaDateTime1 = table.Column<DateTime>(nullable: true),
                    ExtraBool1 = table.Column<bool>(nullable: false),
                    ExtraBool3 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDocType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserActivitiy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Activity = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExtraString1 = table.Column<string>(nullable: true),
                    ExtraString2 = table.Column<string>(nullable: true),
                    ExtraInt1 = table.Column<int>(nullable: true),
                    ExtraDouble1 = table.Column<double>(nullable: false),
                    ExtaDateTime1 = table.Column<DateTime>(nullable: true),
                    ExtraBool1 = table.Column<bool>(nullable: false),
                    ExtraBool3 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivitiy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "AcademicDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameRus = table.Column<string>(nullable: true),
                    NameKaz = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicDepartment_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BDirection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cypher = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    NameKaz = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true),
                    AcademicDepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BDirection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BDirection_AcademicDepartment_AcademicDepartmentId",
                        column: x => x.AcademicDepartmentId,
                        principalTable: "AcademicDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BMajor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cypher = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    NameKaz = table.Column<string>(nullable: true),
                    NameEng = table.Column<string>(nullable: true),
                    StatementNumber = table.Column<string>(nullable: true),
                    AttestationTypeRus = table.Column<string>(nullable: true),
                    AttestationTypeKaz = table.Column<string>(nullable: true),
                    Credits = table.Column<int>(nullable: true),
                    StudyYear = table.Column<string>(nullable: true),
                    AcademicDepartmentId = table.Column<int>(nullable: false),
                    ExtraString1 = table.Column<string>(nullable: true),
                    ExtraString2 = table.Column<string>(nullable: true),
                    ExtraInt1 = table.Column<int>(nullable: true),
                    ExtraDouble1 = table.Column<double>(nullable: true),
                    ExtaDateTime1 = table.Column<DateTime>(nullable: true),
                    ExtraBool1 = table.Column<bool>(nullable: false),
                    ExtraBool3 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BMajor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BMajor_AcademicDepartment_AcademicDepartmentId",
                        column: x => x.AcademicDepartmentId,
                        principalTable: "AcademicDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    UName = table.Column<string>(nullable: true),
                    BMajorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_BMajor_BMajorId",
                        column: x => x.BMajorId,
                        principalTable: "BMajor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BRStudentGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ExtraString1 = table.Column<string>(nullable: true),
                    ExtraString2 = table.Column<string>(nullable: true),
                    ExtraInt1 = table.Column<int>(nullable: true),
                    ExtraDouble1 = table.Column<double>(nullable: true),
                    ExtaDateTime1 = table.Column<DateTime>(nullable: true),
                    ExtraBool1 = table.Column<bool>(nullable: false),
                    ExtraBool3 = table.Column<bool>(nullable: false),
                    BMajorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRStudentGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BRStudentGroup_BMajor_BMajorId",
                        column: x => x.BMajorId,
                        principalTable: "BMajor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "BRStudent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Iin = table.Column<string>(nullable: true),
                    Fname = table.Column<string>(nullable: true),
                    Mname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    ThesisTopicRus = table.Column<string>(nullable: true),
                    ThesisTopicKaz = table.Column<string>(nullable: true),
                    ThesisTopicEng = table.Column<string>(nullable: true),
                    ThesisPagesNumber = table.Column<int>(nullable: true),
                    DrawingsTablesNumber = table.Column<int>(nullable: true),
                    GroupNumber = table.Column<string>(nullable: true),
                    IndividualCypher = table.Column<string>(nullable: true),
                    TimeForQuestions = table.Column<int>(nullable: true),
                    SummarizedSheetNumber = table.Column<string>(nullable: true),
                    StatementNumber = table.Column<string>(nullable: true),
                    ProjectAvailability = table.Column<bool>(nullable: false),
                    DrawingsTablesAvailability = table.Column<bool>(nullable: false),
                    ReviewAvailability = table.Column<bool>(nullable: false),
                    FeedbackAvailability = table.Column<bool>(nullable: false),
                    AvegrageGrade = table.Column<double>(nullable: true),
                    Gpa = table.Column<double>(nullable: true),
                    LetterGrade = table.Column<string>(nullable: true),
                    TraditionalGradeRus = table.Column<string>(nullable: true),
                    TraditionalGradeKaz = table.Column<string>(nullable: true),
                    TraditionalGradeEng = table.Column<string>(nullable: true),
                    ExtraString1 = table.Column<string>(nullable: true),
                    ExtraString2 = table.Column<string>(nullable: true),
                    ExtraString3 = table.Column<string>(nullable: true),
                    ExtraString4 = table.Column<string>(nullable: true),
                    ExtraInt1 = table.Column<int>(nullable: true),
                    ExtraInt2 = table.Column<int>(nullable: true),
                    ExtraInt3 = table.Column<int>(nullable: true),
                    ExtraDouble1 = table.Column<double>(nullable: true),
                    ExtraDouble2 = table.Column<double>(nullable: true),
                    ExtaDateTime1 = table.Column<DateTime>(nullable: true),
                    ExtraDateTime2 = table.Column<DateTime>(nullable: true),
                    ExtraBool1 = table.Column<bool>(nullable: false),
                    ExatraBool2 = table.Column<bool>(nullable: false),
                    ExtraBool3 = table.Column<bool>(nullable: false),
                    SupervisorFname = table.Column<string>(nullable: true),
                    SupervisorMname = table.Column<string>(nullable: true),
                    SupervisorLname = table.Column<string>(nullable: true),
                    SupervisorWorkPlace = table.Column<string>(nullable: true),
                    SupervisorPosition = table.Column<string>(nullable: true),
                    SupervisorAcademicDegree = table.Column<string>(nullable: true),
                    SupervisorReviewAvailability = table.Column<string>(nullable: true),
                    SupervisorConclusion = table.Column<string>(nullable: true),
                    ReviewerFname = table.Column<string>(nullable: true),
                    ReviewerMname = table.Column<string>(nullable: true),
                    ReviewerLname = table.Column<string>(nullable: true),
                    ReviewerWorkPlace = table.Column<string>(nullable: true),
                    ReviewerPosition = table.Column<string>(nullable: true),
                    ReviewerAcademicDegree = table.Column<string>(nullable: true),
                    ReviewerGrade = table.Column<int>(nullable: true),
                    ReviewerReviewAvailability = table.Column<string>(nullable: true),
                    ConsultantFname = table.Column<string>(nullable: true),
                    ConsultantMname = table.Column<string>(nullable: true),
                    ConsultantLname = table.Column<string>(nullable: true),
                    ConsultantWorkPlace = table.Column<string>(nullable: true),
                    ConsultantPosition = table.Column<string>(nullable: true),
                    ConsultantAcademicDegree = table.Column<string>(nullable: true),
                    ProtocolNumber = table.Column<string>(nullable: true),
                    DefenceDate = table.Column<DateTime>(nullable: true),
                    TypeOfStateAttestation = table.Column<string>(nullable: true),
                    CreditNumber = table.Column<int>(nullable: true),
                    StudyYear = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    AnswerCharacteristic = table.Column<string>(nullable: true),
                    LevelOfPreparation = table.Column<string>(nullable: true),
                    AbsentMemberFullName = table.Column<string>(nullable: true),
                    BRStudentGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BRStudent_BRStudentGroup_BRStudentGroupId",
                        column: x => x.BRStudentGroupId,
                        principalTable: "BRStudentGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BRStudentDoc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BRStudentId = table.Column<int>(nullable: false),
                    StudentDocTypeId = table.Column<int>(nullable: false),
                    ExtraString1 = table.Column<string>(nullable: true),
                    ExtraString2 = table.Column<string>(nullable: true),
                    ExtraInt1 = table.Column<int>(nullable: true),
                    ExtraDouble1 = table.Column<double>(nullable: true),
                    ExtaDateTime1 = table.Column<DateTime>(nullable: true),
                    ExtraBool1 = table.Column<bool>(nullable: false),
                    ExtraBool3 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRStudentDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BRStudentDoc_BRStudent_BRStudentId",
                        column: x => x.BRStudentId,
                        principalTable: "BRStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BRStudentDoc_StudentDocType_StudentDocTypeId",
                        column: x => x.StudentDocTypeId,
                        principalTable: "StudentDocType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BRStudentGrade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<int>(nullable: false),
                    Opinion = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    ExtraString1 = table.Column<string>(nullable: true),
                    ExtraString2 = table.Column<string>(nullable: true),
                    ExtraInt1 = table.Column<int>(nullable: true),
                    ExtraDouble1 = table.Column<double>(nullable: true),
                    ExtaDateTime1 = table.Column<DateTime>(nullable: true),
                    ExtraBool1 = table.Column<bool>(nullable: false),
                    ExtraBool3 = table.Column<bool>(nullable: false),
                    BRStudentId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRStudentGrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BRStudentGrade_BRStudent_BRStudentId",
                        column: x => x.BRStudentId,
                        principalTable: "BRStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BRStudentGrade_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicDepartment_FacultyId",
                table: "AcademicDepartment",
                column: "FacultyId");

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
                name: "IX_AspNetUsers_BMajorId",
                table: "AspNetUsers",
                column: "BMajorId");

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
                name: "IX_BDirection_AcademicDepartmentId",
                table: "BDirection",
                column: "AcademicDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BMajor_AcademicDepartmentId",
                table: "BMajor",
                column: "AcademicDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BRStudent_BRStudentGroupId",
                table: "BRStudent",
                column: "BRStudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BRStudentDoc_BRStudentId",
                table: "BRStudentDoc",
                column: "BRStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_BRStudentDoc_StudentDocTypeId",
                table: "BRStudentDoc",
                column: "StudentDocTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BRStudentGrade_BRStudentId",
                table: "BRStudentGrade",
                column: "BRStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_BRStudentGrade_UserId",
                table: "BRStudentGrade",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BRStudentGroup_BMajorId",
                table: "BRStudentGroup",
                column: "BMajorId");
        }

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
                name: "BDirection");

            migrationBuilder.DropTable(
                name: "BRStudentDoc");

            migrationBuilder.DropTable(
                name: "BRStudentGrade");

            migrationBuilder.DropTable(
                name: "DictionaryAcademicDegree");

            migrationBuilder.DropTable(
                name: "DictionaryStatusAvailability");

            migrationBuilder.DropTable(
                name: "DictionaryStatusConclusion");

            migrationBuilder.DropTable(
                name: "DictionaryStudyYear");

            migrationBuilder.DropTable(
                name: "GradesTable");

            migrationBuilder.DropTable(
                name: "UserActivitiy");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "StudentDocType");

            migrationBuilder.DropTable(
                name: "BRStudent");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BRStudentGroup");

            migrationBuilder.DropTable(
                name: "BMajor");

            migrationBuilder.DropTable(
                name: "AcademicDepartment");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
