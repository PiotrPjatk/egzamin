namespace EgzaminTrue.Models;

public class PrescriptionDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public string PatientLastName { get; set; }
    public string DoctorLastName { get; set; }
}

public class CreatePrescriptionDto
{
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
}

public class PrescriptionResponseDto
{
    public int IdPrescription { get; set; }
    public CreatePrescriptionDto Prescription { get; set; }
}