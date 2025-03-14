using HospitalPortal.Core.Entities;
using HospitalPortal.WEB.Models;
using System.Net.Http.Json;

namespace HospitalPortal.WEB.Services
{
	public class AppointmentService : IAppointmentService
	{
		private readonly HttpClient _httpClient;
		public AppointmentService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<bool> AddAppointment(AppointmentCreate appointmentCreateModel)
		{
			var response = await _httpClient.PostAsJsonAsync("api/appointments", appointmentCreateModel);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeleteAppointmentByIdAsync(int appointmentId)
		{
			var response = await _httpClient.DeleteAsync($"api/appointments/{appointmentId}");
			return response.IsSuccessStatusCode;
		}

		public async Task<List<AppointmentDto>> GetAppointmentsByDoctorIdAsync(int doctorId)
		{
			List<AppointmentDto> data = await _httpClient.GetFromJsonAsync<List<AppointmentDto>>($"api/appointments/doctor/{doctorId}");
			return data;
		}

		public async Task<List<AppointmentDto>> GetAppointmentsByPatientIdAsync(int patientId)
		{
			List<AppointmentDto> data = await _httpClient.GetFromJsonAsync<List<AppointmentDto>>($"api/appointments/patient/{patientId}");
			return data;
		}
	}
}
