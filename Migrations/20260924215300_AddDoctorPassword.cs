using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAppointmentMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 1,
                column: "Password",
                value: "");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 2,
                column: "Password",
                value: "");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 3,
                column: "Password",
                value: "");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 4,
                column: "Password",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Doctors");
        }
    }
}
