using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAppointmentMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDoctorLoginDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "thando@clinic.com", "Doctor123" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 2,
                columns: new[] { "Email", "Password" },
                values: new object[] { "ayanda@clinic.com", "Doctor123" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 3,
                columns: new[] { "Email", "Password" },
                values: new object[] { "lerato@clinic.com", "Doctor123" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 4,
                columns: new[] { "Email", "Password" },
                values: new object[] { "sibusiso@clinic.com", "Doctor123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "dr.mkhize@mediflow.co.za", "" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 2,
                columns: new[] { "Email", "Password" },
                values: new object[] { "dr.dlamini@mediflow.co.za", "" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 3,
                columns: new[] { "Email", "Password" },
                values: new object[] { "dr.ndlovu@mediflow.co.za", "" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 4,
                columns: new[] { "Email", "Password" },
                values: new object[] { "dr.khumalo@mediflow.co.za", "" });
        }
    }
}
