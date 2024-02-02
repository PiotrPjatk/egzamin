using System.ComponentModel.DataAnnotations;

namespace EgzaminTrue.Models;

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }

    [Required, StringLength(100)]
    public string FirstName { get; set; }

    [Required, StringLength(100)]
    public string LastName { get; set; }

    [StringLength(100)]
    public string Email { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; }
}