using HospitalPortal.WEB.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace HospitalPortal.WEB.Services
{
	public class MedicationService : IMedicationService
	{
		private readonly HttpClient _httpClient;

		public MedicationService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<List<MedicationDto>> GetMedicationsAsync()
		{
			var data = await _httpClient.GetFromJsonAsync<List<MedicationDto>>($"api/medication");
			return data;
		}
	}
}
