using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgzaminTrue.Models;

public class Prescription_Medicament
{
    [Key, Column(Order = 0)]
    [ForeignKey("Medicament")]
    public int IdMedicament { get; set; }

    [Key, Column(Order = 1)]
    [ForeignKey("Prescription")]
    public int IdPrescription { get; set; }

    public int Dose { get; set; }

    [StringLength(100)]
    public string Details { get; set; }

    public virtual Medicament Medicament { get; set; }
    public virtual Prescription Prescription { get; set; }
}