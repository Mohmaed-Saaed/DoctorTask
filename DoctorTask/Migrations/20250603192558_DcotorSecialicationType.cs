using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoctorTask.Migrations
{
    /// <inheritdoc />
    public partial class DcotorSecialicationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "doctors");

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "dcotorSecialicationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dcotorSecialicationTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "dcotorSecialicationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cardiology" },
                    { 2, "Pediatrics" },
                    { 3, "Dermatology" },
                    { 4, "Orthopedics" },
                    { 5, "Neurology" }
                });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "SpecializationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "SpecializationId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "SpecializationId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "SpecializationId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "SpecializationId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_doctors_SpecializationId",
                table: "doctors",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_dcotorSecialicationTypes_SpecializationId",
                table: "doctors",
                column: "SpecializationId",
                principalTable: "dcotorSecialicationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_dcotorSecialicationTypes_SpecializationId",
                table: "doctors");

            migrationBuilder.DropTable(
                name: "dcotorSecialicationTypes");

            migrationBuilder.DropIndex(
                name: "IX_doctors_SpecializationId",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "doctors");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Specialization",
                value: "Cardiology");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Specialization",
                value: "Pediatrics");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Specialization",
                value: "Dermatology");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Specialization",
                value: "Orthopedics");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Specialization",
                value: "Neurology");
        }
    }
}
