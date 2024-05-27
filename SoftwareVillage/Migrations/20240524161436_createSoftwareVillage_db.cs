using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareVillage.Migrations
{
    /// <inheritdoc />
    public partial class createSoftwareVillage_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "akademiyaAboutUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutUs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Special1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Special2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Special3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Special4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_akademiyaAboutUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bootcamps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bootcamps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "carousel_DataSciences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carousel_DataSciences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "carousel_Designs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carousel_Designs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "carousel_ITAndCybersecurities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carousel_ITAndCybersecurities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "carouselProgrammings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carouselProgrammings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dataSciences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogSubtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignOfMoney = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payment = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description5 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataSciences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "designs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogSubtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignOfMoney = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payment = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description5 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Down_SoftwareVillages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxCountOfTeachers = table.Column<int>(type: "int", nullable: false),
                    Icon2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxCountOfStudents = table.Column<int>(type: "int", nullable: false),
                    Icon3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxCountOfPartnyors = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Down_SoftwareVillages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ITandCybersecurities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogSubtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignOfMoney = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payment = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description5 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITandCybersecurities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "it_SoftwareVillages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LittleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BigTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_it_SoftwareVillages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "layouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_layouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Missiyamız",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Controller_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    View_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missiyamız", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "muracietler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bigtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Smalltitle1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Smalltitle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Smalltitle3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_muracietler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "niye_SoftwareVillage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_niye_SoftwareVillage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partnyors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partnyors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "professions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "programming",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogSubtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignOfMoney = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payment = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description5 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programming", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "relation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "socialMediaOfTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TwitterLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstagramLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedlnLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socialMediaOfTeachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    AdditionPhone = table.Column<int>(type: "int", nullable: false),
                    Payment = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studentsFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BootcampId = table.Column<int>(type: "int", nullable: false),
                    Feedbacks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentsFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentsFeedbacks_bootcamps_BootcampId",
                        column: x => x.BootcampId,
                        principalTable: "bootcamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "akademiyaTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_akademiyaTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_akademiyaTeachers_professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_akademiyaTeachers_socialMediaOfTeachers_SocialMediaId",
                        column: x => x.SocialMediaId,
                        principalTable: "socialMediaOfTeachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentsOfBootcamps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BootcampId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentsOfBootcamps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentsOfBootcamps_bootcamps_BootcampId",
                        column: x => x.BootcampId,
                        principalTable: "bootcamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentsOfBootcamps_students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentsOfTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentsOfTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentsOfTeachers_akademiyaTeachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "akademiyaTeachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentsOfTeachers_students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_akademiyaTeachers_ProfessionId",
                table: "akademiyaTeachers",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_akademiyaTeachers_SocialMediaId",
                table: "akademiyaTeachers",
                column: "SocialMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_studentsFeedbacks_BootcampId",
                table: "studentsFeedbacks",
                column: "BootcampId");

            migrationBuilder.CreateIndex(
                name: "IX_studentsOfBootcamps_BootcampId",
                table: "studentsOfBootcamps",
                column: "BootcampId");

            migrationBuilder.CreateIndex(
                name: "IX_studentsOfBootcamps_StudentsId",
                table: "studentsOfBootcamps",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_studentsOfTeachers_StudentsId",
                table: "studentsOfTeachers",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_studentsOfTeachers_TeachersId",
                table: "studentsOfTeachers",
                column: "TeachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "akademiyaAboutUs");

            migrationBuilder.DropTable(
                name: "carousel_DataSciences");

            migrationBuilder.DropTable(
                name: "carousel_Designs");

            migrationBuilder.DropTable(
                name: "carousel_ITAndCybersecurities");

            migrationBuilder.DropTable(
                name: "carouselProgrammings");

            migrationBuilder.DropTable(
                name: "dataSciences");

            migrationBuilder.DropTable(
                name: "designs");

            migrationBuilder.DropTable(
                name: "Down_SoftwareVillages");

            migrationBuilder.DropTable(
                name: "ITandCybersecurities");

            migrationBuilder.DropTable(
                name: "it_SoftwareVillages");

            migrationBuilder.DropTable(
                name: "layouts");

            migrationBuilder.DropTable(
                name: "Missiyamız");

            migrationBuilder.DropTable(
                name: "muracietler");

            migrationBuilder.DropTable(
                name: "niye_SoftwareVillage");

            migrationBuilder.DropTable(
                name: "Partnyors");

            migrationBuilder.DropTable(
                name: "programming");

            migrationBuilder.DropTable(
                name: "relation");

            migrationBuilder.DropTable(
                name: "studentsFeedbacks");

            migrationBuilder.DropTable(
                name: "studentsOfBootcamps");

            migrationBuilder.DropTable(
                name: "studentsOfTeachers");

            migrationBuilder.DropTable(
                name: "bootcamps");

            migrationBuilder.DropTable(
                name: "akademiyaTeachers");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "professions");

            migrationBuilder.DropTable(
                name: "socialMediaOfTeachers");
        }
    }
}
