using HospitalPortal.Core.Entities;
using HospitalPortal.WEB.Models;
using System.Net.Http.Json;

namespace HospitalPortal.WEB.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HttpClient _httpClient;
        public DoctorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<DoctorDto>> GetDoctorsAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<List<DoctorDto>>($"api/doctors");
            return data;
        }
        public async Task<DoctorDto> GetDoctorByIdAsync(int doctorId)
        {
            var data = await _httpClient.GetFromJsonAsync<DoctorDto>($"api/doctors/{doctorId}");
            return data;
        }
    }
}
