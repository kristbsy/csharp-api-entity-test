using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            return TypedResults.Ok(patients.Select(p => new PatientGetDTO(p)).ToList());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            return TypedResults.Ok(doctors.Select(d => new DoctorGetDto(d)).ToList());
        }

        public static async Task<IResult> GetDoctor(IRepository repo, int id)
        {
            var doctor = await repo.GetDoctor(id);
            if (doctor == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new DoctorGetDto(doctor));
        }

        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPostDto doc)
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            return TypedResults.Ok(appointments.Select(a => new AppointmentWithoutDoctor(a)));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByPatient(id);
            return TypedResults.Ok(appointments.Select(a => new AppointmentWithoutPatient(a)));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointments();
            return TypedResults.Ok(appointments.Select(a => new AppointmentGetDto(a)));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointment(IRepository repository, int id)
        {
            var appointment = await repository.GetAppointment(id);
            if (appointment == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new AppointmentGetDto(appointment));
        }

        public static async Task<IResult> CreateAppointment(
            IRepository repo,
            AppointmentPostDto app
        )
        {
            throw new NotImplementedException();
        }
    }
}
