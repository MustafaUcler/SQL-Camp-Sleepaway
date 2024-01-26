using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SP2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabins",
                columns: table => new
                {
                    CabinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabinColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabins", x => x.CabinId);
                });

            migrationBuilder.CreateTable(
                name: "Campers",
                columns: table => new
                {
                    CamperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabinId = table.Column<int>(type: "int", nullable: true),
                    MoveInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoveOutDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campers", x => x.CamperId);
                    table.ForeignKey(
                        name: "FK_Campers_Cabins_CabinId",
                        column: x => x.CabinId,
                        principalTable: "Cabins",
                        principalColumn: "CabinId");
                });

            migrationBuilder.CreateTable(
                name: "Counselors",
                columns: table => new
                {
                    CounselorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    YearsExperience = table.Column<int>(type: "int", nullable: true),
                    CabinId = table.Column<int>(type: "int", nullable: true),
                    ResponsibilityStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponsibilityEndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counselors", x => x.CounselorId);
                    table.ForeignKey(
                        name: "FK_Counselors_Cabins_CabinId",
                        column: x => x.CabinId,
                        principalTable: "Cabins",
                        principalColumn: "CabinId");
                });

            migrationBuilder.CreateTable(
                name: "NextOfKins",
                columns: table => new
                {
                    NextOfKinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CamperId = table.Column<int>(type: "int", nullable: false),
                    RelationToCamper = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoveOutDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKins", x => x.NextOfKinId);
                    table.ForeignKey(
                        name: "FK_NextOfKins_Campers_CamperId",
                        column: x => x.CamperId,
                        principalTable: "Campers",
                        principalColumn: "CamperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cabins",
                columns: new[] { "CabinId", "CabinColor", "CabinName" },
                values: new object[,]
                {
                    { 1, "Blue", "Cabin1" },
                    { 2, "Green", "Cabin2" },
                    { 3, "Red", "Cabin3" },
                    { 4, "Yellow", "Cabin4" },
                    { 5, "White", "Cabin5" },
                    { 6, "Black", "Cabin6" },
                    { 7, "Brown", "Cabin7" },
                    { 8, "Orange", "Cabin8" }
                });

            migrationBuilder.InsertData(
                table: "Campers",
                columns: new[] { "CamperId", "Age", "CabinId", "FirstName", "Gender", "LastName", "MoveInDate", "MoveOutDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 18, 1, "Camper1", "Female", "Last1", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "4444444444" },
                    { 2, 18, 1, "Camper2", "Male", "Last2", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "5555555555" },
                    { 3, 18, 1, "Camper3", "Female", "Last3", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "6666666666" },
                    { 4, 18, 1, "Camper4", "Male", "Last4", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "7777777777" },
                    { 5, 18, 2, "Camper5", "Female", "Last5", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "8888888888" },
                    { 6, 18, 2, "Camper6", "Male", "Last6", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "9999999999" },
                    { 7, 18, 2, "Camper7", "Female", "Last7", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "1010101010" },
                    { 8, 18, 2, "Camper8", "Male", "Last8", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "1111111111" },
                    { 9, 18, 3, "Camper9", "Female", "Last9", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "1212121212" },
                    { 10, 18, 3, "Camper10", "Male", "Last10", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "1313131313" },
                    { 11, 18, 3, "Camper11", "Female", "Last11", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "1414141414" },
                    { 12, 18, 3, "Camper12", "Male", "Last12", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "1515151515" },
                    { 13, 18, 4, "Camper13", "Female", "Last13", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "1616161616" },
                    { 14, 18, 4, "Camper14", "Male", "Last14", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "1717171717" },
                    { 15, 18, 4, "Camper15", "Female", "Last15", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "1818181818" },
                    { 16, 0, 4, "Camper16", "Male", "Last16", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "1919191919" },
                    { 17, 0, 5, "Camper17", "Male", "Last17", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "2020202020" },
                    { 18, 0, 5, "Camper18", "Female", "Last18", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "2121212121" }
                });

            migrationBuilder.InsertData(
                table: "Counselors",
                columns: new[] { "CounselorId", "Age", "CabinId", "FirstName", "LastName", "ResponsibilityEndDate", "ResponsibilityStartDate", "YearsExperience" },
                values: new object[,]
                {
                    { 1, 18, 1, "Counselor1", "Last1", new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), 2 },
                    { 2, 18, 2, "Counselor2", "Last2", new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), 3 },
                    { 3, 18, 3, "Counselor3", "Last3", new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), 1 },
                    { 4, 18, 4, "Counselor4", "Last4", new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), 2 },
                    { 5, 18, 5, "Counselor5", "Last5", new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), 3 },
                    { 6, 18, 6, "Counselor6", "Last6", new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), 1 }
                });

            migrationBuilder.InsertData(
                table: "NextOfKins",
                columns: new[] { "NextOfKinId", "Age", "CamperId", "FirstName", "Gender", "LastName", "MoveInDate", "MoveOutDate", "PhoneNumber", "RelationToCamper" },
                values: new object[,]
                {
                    { 1, 40, 1, "Parent1", "Female", "Last1", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "4567890123", "Parent" },
                    { 2, 40, 2, "Parent2", "Male", "Last2", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "5678901234", "Parent" },
                    { 3, 40, 3, "Parent3", "Female", "Last3", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "6789012345", "Parent" },
                    { 4, 40, 4, "Parent4", "Male", "Last4", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "7890123456", "Parent" },
                    { 5, 40, 5, "Parent5", "Male", "Last5", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "8901234567", "Parent" },
                    { 6, 40, 6, "Parent6", "Female", "Last6", new DateTime(2024, 1, 4, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 1, 11, 22, 34, 49, 655, DateTimeKind.Local).AddTicks(9214), "9012345678", "Parent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campers_CabinId",
                table: "Campers",
                column: "CabinId");

            migrationBuilder.CreateIndex(
                name: "IX_Counselors_CabinId",
                table: "Counselors",
                column: "CabinId",
                unique: true,
                filter: "[CabinId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_CamperId",
                table: "NextOfKins",
                column: "CamperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Counselors");

            migrationBuilder.DropTable(
                name: "NextOfKins");

            migrationBuilder.DropTable(
                name: "Campers");

            migrationBuilder.DropTable(
                name: "Cabins");
        }
    }
}
