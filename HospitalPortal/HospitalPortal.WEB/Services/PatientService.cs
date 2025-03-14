using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using HospitalPortal.WEB.Models;
using HospitalPortal.WEB.Services;

namespace HospitalPortal.Blazor.Services
{
	public class PatientService : IPatientService
	{
		private readonly HttpClient _httpClient;

		public PatientService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<PatientDto> GetPatientByIdAsync(int patientId)
		{
			var data = await _httpClient.GetFromJsonAsync<PatientDto>($"api/patients/{patientId}");
			return data;
		}

		public async Task<bool> AddPatientAsync(PatientCreate patientCreateModel)
		{
			var response = await _httpClient.PostAsJsonAsync("api/patients", patientCreateModel);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> UpdatePatientAsync(int patientId, PatientUpdate patientDto)
		{
			var response = await _httpClient.PutAsJsonAsync($"api/patients/{patientId}", patientDto);
			return response.IsSuccessStatusCode;
		}

		public async Task<bool> DeletePatientAsync(int patientId)
		{
			var response = await _httpClient.DeleteAsync($"api/patients/{patientId}");
			return response.IsSuccessStatusCode;
		}

        public async Task<bool> ChangePasswordAsync(int patientId, PasswordChange passwordChange)
        {
			var response = await _httpClient.PutAsJsonAsync($"api/patients/{patientId}/change-password", passwordChange);
			return response.IsSuccessStatusCode;
        }
    }
}
