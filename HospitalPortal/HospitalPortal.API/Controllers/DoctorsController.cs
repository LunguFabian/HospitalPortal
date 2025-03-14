using HospitalPortal.API.Models;
using HospitalPortal.Core.Entities;
using HospitalPortal.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalPortal.API.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class DoctorsController : ControllerBase
	{
		private readonly IDoctorRepository _doctorRepository;
		public DoctorsController(IDoctorRepository doctorRepository)
		{
			_doctorRepository = doctorRepository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<DoctorDto>> GetDoctors()
		{
			var doctors = _doctorRepository.GetDoctors();
			var doctorDtos = doctors.Select(doctor => new DoctorDto
			{
				Id = doctor.Id,
				LastName = doctor.LastName,
				FirstName = doctor.FirstName,
				Email = doctor.Email,
				DoctorCode = doctor.DoctorCode,
				Specialization = doctor.Specialization?.Name
			}).ToList();
			return Ok(doctorDtos);
		}
		[Authorize(Roles = "Doctor")]
		[HttpGet("{doctorId}")]
		public ActionResult<DoctorDto> GetDoctorById(int doctorId)
		{
			var doctor = _doctorRepository.GetDoctorById(doctorId);
			if (doctor == null)
			{
				return NotFound();
			}
			var doctorDto = new DoctorDto
			{
				Id = doctor.Id,
				LastName = doctor.LastName,
				FirstName = doctor.FirstName,
				Email = doctor.Email,
				DoctorCode = doctor.DoctorCode,
				Specialization = doctor.Specialization?.Name
			};
			return Ok(doctorDto);
		}
	}
}
