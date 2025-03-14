using HospitalPortal.API.Models;
using HospitalPortal.Core.Entities;
using HospitalPortal.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPortal.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PrescriptionController : Controller
	{
		private readonly IPrescriptionRepository _prescriptionRepository;
		public PrescriptionController(IPrescriptionRepository prescriptionRepository)
		{
			_prescriptionRepository = prescriptionRepository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<PrescriptionDto>> GetPrescriptions()
		{
			var prescriptions = _prescriptionRepository.GetPrescriptions();
			var prescriptionDtos = prescriptions.Select(p => new PrescriptionDto
			{
				Id = p.Id,
				DoctorId = p.DoctorId,
				DoctorName = $"{p.Doctor.LastName} {p.Doctor.FirstName}",
				PatientName = $"{p.Patient.LastName} {p.Patient.FirstName}",
				Medications = _prescriptionRepository.GetMedicationsByPrescriptionId(p.Id)
					.Select(m => new MedicationDto
					{
						MedicationId = m.MedicationId,
						MedicationName = m.Medication.Name,
						Dosage = m.Dosage,
						Instructions = m.Instructions
					}).ToList(),
				DateCreated = p.DateCreated
			}).ToList();
			return Ok(prescriptionDtos);
		}

		[HttpPost]
		public IActionResult CreatePrescription([FromBody] PrescriptionCreate prescriptionDto)
		{
			if (prescriptionDto == null)
			{
				return BadRequest("Invalid prescription data.");
			}

			var prescription = new Prescriptions
			{
				PatientId = prescriptionDto.PatientId,
				DoctorId = prescriptionDto.DoctorId,
				DateCreated = DateTime.Now
			};

			_prescriptionRepository.CreatePrescription(prescription);

			foreach (var medication in prescriptionDto.Medications)
			{
				var prescriptionMedication = new Prescription_Medication
				{
					PrescriptionId = prescription.Id,
					MedicationId = medication.MedicationId,
					Dosage = medication.Dosage,
					Instructions = medication.Instructions
				};

				_prescriptionRepository.AddMedicationToPrescription(prescriptionMedication);
			}

			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpGet("patient/{patientId}")]
		public IActionResult GetPrescriptionsByPatientId(int patientId)
		{
			var prescriptions = _prescriptionRepository.GetPrescriptionsByPatientId(patientId);

			if (prescriptions == null || !prescriptions.Any())
			{
				return NotFound("No prescriptions found.");
			}

			var prescriptionDtos = prescriptions.Select(p => new PrescriptionDto
			{
				Id = p.Id,
				DoctorId = p.DoctorId,
				DoctorName = $"{p.Doctor.LastName} {p.Doctor.FirstName}",
				PatientName = $"{p.Patient.LastName} {p.Patient.FirstName}",
				Medications = _prescriptionRepository.GetMedicationsByPrescriptionId(p.Id)
					.Select(m => new MedicationDto
					{
						MedicationId = m.MedicationId,
						MedicationName = m.Medication.Name,
						Dosage = m.Dosage,
						Instructions = m.Instructions
					}).ToList(),
				DateCreated = p.DateCreated
			}).ToList();

			return Ok(prescriptionDtos);
		}

		[HttpGet("patient/{patientId}/doctor/{doctorId}")]
		public IActionResult GetPrescriptionsByPatientAndDoctorId(int patientId,int doctorId)
		{
			var prescriptions = _prescriptionRepository.GetPrescriptionsByPatientAndDoctorId(patientId,doctorId);

			if (prescriptions == null || !prescriptions.Any())
			{
				return NotFound("No prescriptions found.");
			}

			var prescriptionDtos = prescriptions.Select(p => new PrescriptionDto
			{
				Id = p.Id,
				DoctorId = p.DoctorId,
				DoctorName = $"{p.Doctor.LastName} {p.Doctor.FirstName}",
				PatientName = $"{p.Patient.LastName} {p.Patient.FirstName}",
				Medications = _prescriptionRepository.GetMedicationsByPrescriptionId(p.Id)
					.Select(m => new MedicationDto
					{
						MedicationId = m.MedicationId,
						MedicationName = m.Medication.Name,
						Dosage = m.Dosage,
						Instructions = m.Instructions
					}).ToList(),
				DateCreated = p.DateCreated
			}).ToList();

			return Ok(prescriptionDtos);
		}
	}
}
