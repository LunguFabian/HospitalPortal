using HospitalPortal.WEB.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HospitalPortal.WEB.Services
{
	public class LoginService : ILoginService
	{
		private readonly HttpClient _httpClient;

		public LoginService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<LoginResult> HandleLoginAsync(LoginRequest loginRequest)
		{
			var response = await _httpClient.PostAsJsonAsync("api/login", loginRequest);
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<LoginResult>();
				return result;
			}
			throw new HttpRequestException("Login failed. Please check your credentials.");
		}
	}
}
