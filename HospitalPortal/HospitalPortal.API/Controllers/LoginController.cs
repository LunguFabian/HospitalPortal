using HospitalPortal.Data.Repositories;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using HospitalPortal.API.Models;
using HospitalPortal.API.Helpers;
using HospitalPortal.Core.Entities;
namespace HospitalPortal.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IPatientRepository _patientRepository;
		private readonly IDoctorRepository _doctorRepository;
		private readonly JwtService _jwtService;
		public LoginController(IPatientRepository patientRepository, IDoctorRepository doctorRepository, JwtService jwtService)
		{
			_patientRepository = patientRepository;
			_doctorRepository = doctorRepository;
			_jwtService = jwtService;
		}

		[HttpPost()]
		public IActionResult Login([FromBody] Models.LoginRequest loginRequest)
		{
			if (string.IsNullOrEmpty(loginRequest.DoctorCode))
			{
				var patient = _patientRepository.GetPatientByEmail(loginRequest.Email);
				if (patient == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, patient.PasswordHash))
				{
					return Unauthorized("Invalid patient credentials.");
				}
				string token = _jwtService.GenerateJwtToken(patient.Id, "Patient");
				return Ok(new LoginResult { Role = "Patient", Id = patient.Id, Token = token });
			}
			else
			{
				var doctor = _doctorRepository.GetDoctorByEmailAndCode(loginRequest.Email, loginRequest.DoctorCode);
				if (doctor == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, doctor.PasswordHash))
				{
					return Unauthorized("Invalid doctor credentials.");
				}
				string token = _jwtService.GenerateJwtToken(doctor.Id, "Doctor");
				return Ok(new LoginResult { Role = "Doctor", Id = doctor.Id, Token = token });
			}
		}
	}
}
