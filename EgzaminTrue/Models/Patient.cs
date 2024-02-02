using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgzaminTrue.Models;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }

    [Required, StringLength(100)]
    public string FirstName { get; set; }

    [Required, StringLength(100)]
    public string LastName { get; set; }

    [Column(TypeName = "date")]
    public DateTime Birthdate { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; }
}