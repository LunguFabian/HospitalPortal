using HospitalPortal.WEB.Models;

namespace HospitalPortal.WEB.Services
{
	public interface IDoctorService
	{
		public Task<List<DoctorDto>> GetDoctorsAsync();
		public Task<DoctorDto> GetDoctorByIdAsync(int doctorId);
	}
}
