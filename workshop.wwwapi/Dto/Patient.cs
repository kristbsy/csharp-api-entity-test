using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository;

public class PatientGetDTO
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public IEnumerable<AppointmentWithoutPatient> Appointments { get; set; }

    public PatientGetDTO(Patient patient)
    {
        this.Id = patient.Id;
        this.FullName = patient.FullName;
        this.Appointments = patient
            .Appointments.Select(a => new AppointmentWithoutPatient(a))
            .ToList();
    }
}

public class PatientShallow
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public PatientShallow(Patient patient)
    {
        this.Id = patient.Id;
        this.FullName = patient.FullName;
    }
}
