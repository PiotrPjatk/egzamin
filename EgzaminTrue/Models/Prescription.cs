using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgzaminTrue.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }

    [Column(TypeName = "date")]
    public DateTime Date { get; set; }

    [Column(TypeName = "date")]
    public DateTime DueDate { get; set; }

    public int IdPatient { get; set; }

    public int IdDoctor { get; set; }

    public virtual Doctor Doctor { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual ICollection<Prescription_Medicament> Prescription_Medicament { get; set; }
}