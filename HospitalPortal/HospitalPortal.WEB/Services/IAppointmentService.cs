using HospitalPortal.WEB.Models;

namespace HospitalPortal.WEB.Services
{
	public interface IAppointmentService
	{
		public Task<List<AppointmentDto>> GetAppointmentsByPatientIdAsync(int patientId);
		public Task<List<AppointmentDto>> GetAppointmentsByDoctorIdAsync(int doctorId);
		public Task<bool> AddAppointment(AppointmentCreate appointmentCreateModel);
		public Task<bool> DeleteAppointmentByIdAsync(int appointmentId);
	}
}
