using HospitalPortal.WEB.Models;
using System.Net.Http.Json;

namespace HospitalPortal.WEB.Services
{
	public class PrescriptionService : IPrescriptionService
	{
		private readonly HttpClient _httpClient;

		public PrescriptionService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<PrescriptionDto>> GetPrescriptionsByPatientIdAsync(int patientId)
		{
			var response = await _httpClient.GetFromJsonAsync<List<PrescriptionDto>>($"/api/prescription/patient/{patientId}");
			return response;
		}
		public async Task<bool> CreatePrescriptionAsync(PrescriptionCreate prescriptionCreateModel)
		{
			var response = await _httpClient.PostAsJsonAsync("api/prescription", prescriptionCreateModel);
			return response.IsSuccessStatusCode;
		}
		public async Task<List<PrescriptionDto>> GetPrescriptionsByPatientAndDoctorIdAsync(int patientId,int doctorId)
		{
			var response = await _httpClient.GetFromJsonAsync<List<PrescriptionDto>>($"/api/prescription/patient/{patientId}/doctor/{doctorId}");
			return response;
		}
	}
}
