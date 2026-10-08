using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicAppointmentMVC.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoctorsAndServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "Email", "Name", "Phone", "Specialisation", "Surname" },
                values: new object[,]
                {
                    { 1, "dr.mkhize@mediflow.co.za", "Thando", "0711111111", "General Practitioner", "Mkhize" },
                    { 2, "dr.dlamini@mediflow.co.za", "Ayanda", "0722222222", "Dentist", "Dlamini" },
                    { 3, "dr.ndlovu@mediflow.co.za", "Lerato", "0733333333", "Physiotherapist", "Ndlovu" },
                    { 4, "dr.khumalo@mediflow.co.za", "Sibusiso", "0744444444", "Paediatrician", "Khumalo" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
