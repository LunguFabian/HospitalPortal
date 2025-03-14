using HospitalPortal.WEB.Models;

namespace HospitalPortal.WEB.Services
{
	public interface IPatientService
	{
		public Task<PatientDto> GetPatientByIdAsync(int patientId);
		public Task<bool> AddPatientAsync(PatientCreate patientCreateModel);
		public Task<bool> UpdatePatientAsync(int patientId, PatientUpdate patientDto);
		public Task<bool> ChangePasswordAsync(int patientId, PasswordChange passwordChange);
		public Task<bool> DeletePatientAsync(int patientId);
	}
}
