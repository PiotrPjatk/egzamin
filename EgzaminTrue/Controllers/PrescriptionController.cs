using EgzaminTrue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EgzaminTrue.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionsController : ControllerBase
{
    private readonly MyDbContext _context;

    public PrescriptionsController(MyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PrescriptionDto>>> GetPrescriptions([FromQuery] string? doctorLastName)
    {
        var query = _context.Prescriptions
            .Include(p => p.Patient)
            .Include(p => p.Doctor)
            .AsQueryable();

        if (!string.IsNullOrEmpty(doctorLastName))
        {
            query = query.Where(p => p.Doctor.LastName == doctorLastName);
        }

        var result = await query.OrderByDescending(p => p.Date)
            .Select(p => new PrescriptionDto
            {
                IdPrescription = p.IdPrescription,
                Date = p.Date,
                DueDate = p.DueDate,
                PatientLastName = p.Patient.LastName,
                DoctorLastName = p.Doctor.LastName
            })
            .ToListAsync();

        return result;
    }
    
    [HttpPost]
    public async Task<ActionResult<PrescriptionResponseDto>> CreatePrescription(CreatePrescriptionDto createPrescriptionDto)
    {
        if (createPrescriptionDto.DueDate < createPrescriptionDto.Date)
        {
            return BadRequest("DueDate must be later than Date.");
        }

        var prescription = new Prescription
        {
            Date = createPrescriptionDto.Date,
            DueDate = createPrescriptionDto.DueDate,
            IdPatient = createPrescriptionDto.IdPatient,
            IdDoctor = createPrescriptionDto.IdDoctor
        };

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();

        var response = new PrescriptionResponseDto
        {
            IdPrescription = prescription.IdPrescription,
            Prescription = createPrescriptionDto
        };

        return StatusCode(StatusCodes.Status201Created, response);
    }
}