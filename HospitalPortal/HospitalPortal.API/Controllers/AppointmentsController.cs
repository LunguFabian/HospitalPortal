using HospitalPortal.API.Models;
using HospitalPortal.Core.Entities;
using HospitalPortal.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace HospitalPortal.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppointmentsController : ControllerBase
	{
		private readonly IAppointmentRepository _appointmentRepository;
		public AppointmentsController(IAppointmentRepository appointmentRepository)
		{
			_appointmentRepository = appointmentRepository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<AppointmentDto>> GetAppointments()
		{
			var appointments = _appointmentRepository.GetAppointments();
			var appointmentDtos = appointments.Select(appointment => new AppointmentDto
			{
				Id = appointment.Id,
				DoctorName = $"{appointment.Doctor.LastName} {appointment.Doctor.FirstName}",
				PatientName = $"{appointment.Patient.LastName} {appointment.Patient.FirstName}",
				DateAndHour = appointment.DateAndHour,
				StatusName = appointment.Status?.StatusDescription
			}).ToList();
			return Ok(appointmentDtos);
		}

		[HttpGet("patient/{patientId}")]
		public ActionResult<IEnumerable<AppointmentDto>> GetAppointmentsByPatientId(int patientId)
		{
			var appointments = _appointmentRepository.GetAppointmentsByPatientId(patientId);

			if (appointments == null)
			{
				return NotFound();
			}
			foreach (var appointment in appointments)
			{
				if (appointment.DateAndHour < DateTime.Now && appointment.StatusId != 2)
				{
					appointment.StatusId = 2;
					_appointmentRepository.UpdateAppointmentStatus(appointment);
				}
			}

			appointments = _appointmentRepository.GetAppointmentsByPatientId(patientId);
			var appointmentDtos = appointments.Select(appointment => new AppointmentDto
			{
				Id = appointment.Id,
				DoctorName = $"{appointment.Doctor.FirstName} {appointment.Doctor.LastName}",
				PatientName = $"{appointment.Patient.FirstName} {appointment.Patient.LastName}",
				DateAndHour = appointment.DateAndHour,
				StatusName = appointment.Status?.StatusDescription,
				PatientId = patientId
			}).ToList();
			return Ok(appointmentDtos);
		}

		[HttpGet("doctor/{doctorId}")]
		public ActionResult<IEnumerable<AppointmentDto>> GetAppointmentsByDoctortId(int doctorId)
		{
			var appointments = _appointmentRepository.GetAppointmentsByDoctorId(doctorId);

			if (appointments == null)
			{
				return NotFound();
			}
			foreach (var appointment in appointments)
			{
				if (appointment.DateAndHour < DateTime.Now && appointment.StatusId != 2)
				{
					appointment.StatusId = 2;
					_appointmentRepository.UpdateAppointmentStatus(appointment);
				}
			}

			appointments = _appointmentRepository.GetAppointmentsByDoctorId(doctorId);

			var appointmentDtos = appointments.Select(appointment => new AppointmentDto
			{
				Id = appointment.Id,
				DoctorName = $"{appointment.Doctor.FirstName} {appointment.Doctor.LastName}",
				PatientName = $"{appointment.Patient.FirstName} {appointment.Patient.LastName}",
				DateAndHour = appointment.DateAndHour,
				StatusName = appointment.Status?.StatusDescription,
				PatientId = appointment.Patient.Id
			}).ToList();
			return Ok(appointmentDtos);
		}

		[HttpPost]
		public ActionResult<AppointmentDto> AddAppointment([FromBody] AppointmentCreate appointmentCreateModel)
		{
			if (appointmentCreateModel == null)
			{
				return BadRequest("Appointment data must not be null!");
			}

			var newAppointment = new Appointments
			{
				DoctorId = appointmentCreateModel.DoctorId,
				PatientId = appointmentCreateModel.PatientId,
				StatusId = appointmentCreateModel.StatusId,
				DateAndHour = appointmentCreateModel.DateAndHour,
			};

			_appointmentRepository.AddAppointment(newAppointment);

			return StatusCode(StatusCodes.Status201Created);

		}

		[HttpDelete("{appointmentId}")]
		public IActionResult DeleteAppointment(int appointmentId)
		{
			var appointment = _appointmentRepository.GetAppointmentById(appointmentId);

			if (appointment == null)
			{
				return NotFound("Appointment Not Found.");
			}

			_appointmentRepository.DeleteAppointment(appointmentId);
			return StatusCode(StatusCodes.Status204NoContent);
		}
	}
}
