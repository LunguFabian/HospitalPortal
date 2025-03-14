using HospitalPortal.API.Models;
using HospitalPortal.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using BCrypt;
using HospitalPortal.Core.Entities;
using Microsoft.AspNetCore.Authorization;


namespace HospitalPortal.API.Controllers
{
	[Authorize(Roles = "Patient")]
	[Route("api/[controller]")]
	[ApiController]
	public class PatientsController : ControllerBase
	{
		private readonly IPatientRepository _patientRepository;
		public PatientsController(IPatientRepository patientRepository)
		{
			_patientRepository = patientRepository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<PatientDto>> GetPatients()
		{
			var patients = _patientRepository.GetPatients();
			return Ok(patients);
		}

		[HttpGet("{patientId}")]
		public ActionResult<PatientDto> GetPatientById(int patientId)
		{
			var patient = _patientRepository.GetPatientById(patientId);
			if (patient == null)
			{
				return NotFound();
			}
			var patientDto = new PatientDto
			{
				FirstName = patient.FirstName,
				LastName = patient.LastName,
				CNP = patient.CNP,
				Email = patient.Email,
				Id = patient.Id,
			};
			return Ok(patientDto);
		}

		[HttpPost()]
		public ActionResult<PatientDto> AddPatient([FromBody] PatientCreate patientCreateModel)
		{
			if (patientCreateModel == null)
			{
				return BadRequest("Patient data must not be null!");
			}

			var newPatient = new Patients
			{
				LastName = patientCreateModel.LastName,
				FirstName = patientCreateModel.FirstName,
				Email = patientCreateModel.Email,
				CNP = patientCreateModel.CNP,
				PasswordHash = BCrypt.Net.BCrypt.HashPassword(patientCreateModel.Password),
			};

			var verifyPatient = _patientRepository.GetPatientByEmail(newPatient.Email);
			if (verifyPatient != null)
			{
				return Conflict(new { message = "Email is already in use." });
			}

			_patientRepository.AddPatient(newPatient);

			return StatusCode(StatusCodes.Status201Created);

		}

		[HttpDelete("{patientId}")]
		public IActionResult DeletePatient(int patientId)
		{
			var patient = _patientRepository.GetPatientById(patientId);

			if (patient == null)
			{
				return NotFound("Patient not found.");
			}

			_patientRepository.DeletePatient(patientId);
			return StatusCode(StatusCodes.Status204NoContent);
		}

		[HttpPut("{patientId}")]
		public IActionResult UpdatePatientProfile(int patientId, [FromBody] PatientUpdate patientUpdate)
		{
			if (patientUpdate == null)
			{
				return BadRequest("Profile update data is invalid.");
			}

			var existingPatient = _patientRepository.GetPatientById(patientId);
			if (existingPatient == null)
			{
				return NotFound("Patient not found.");
			}

			existingPatient.LastName = patientUpdate.LastName;
			existingPatient.FirstName = patientUpdate.FirstName;
			existingPatient.Email = patientUpdate.Email;

			_patientRepository.UpdatePatient(existingPatient);
			return NoContent();
		}

		[HttpPut("{patientId}/change-password")]
		public IActionResult ChangePassword(int patientId, [FromBody] PasswordChange passwordChange)
		{
			if (passwordChange == null)
			{
				return BadRequest("Password change data is invalid.");
			}

			var existingPatient = _patientRepository.GetPatientById(patientId);
			if (existingPatient == null)
			{
				return NotFound("Patient not found.");
			}

			if (!BCrypt.Net.BCrypt.Verify(passwordChange.CurrentPassword, existingPatient.PasswordHash))
			{
				return BadRequest("Current password is incorrect.");
			}

			existingPatient.PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordChange.NewPassword);

			_patientRepository.UpdatePatient(existingPatient);
			return NoContent();
		}
	}

}