using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicAppointmentMVC.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDemoDoctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceID",
                keyValue: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "Email", "Name", "Password", "Phone", "Specialisation", "Surname" },
                values: new object[,]
                {
                    { 1, "thando@clinic.com", "Thando", "Doctor123", "0711111111", "General Practitioner", "Mkhize" },
                    { 2, "ayanda@clinic.com", "Ayanda", "Doctor123", "0722222222", "Dentist", "Dlamini" },
                    { 3, "lerato@clinic.com", "Lerato", "Doctor123", "0733333333", "Physiotherapist", "Ndlovu" },
                    { 4, "sibusiso@clinic.com", "Sibusiso", "Doctor123", "0744444444", "Paediatrician", "Khumalo" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "Description", "ServiceName" },
                values: new object[,]
                {
                    { 1, "General medical consultation.", "General Consultation" },
                    { 2, "Dental examination and consultation.", "Dental Consultation" },
                    { 3, "Physical rehabilitation and treatment.", "Physiotherapy" },
                    { 4, "Medical consultation for children.", "Child Consultation" }
                });
        }
    }
}
