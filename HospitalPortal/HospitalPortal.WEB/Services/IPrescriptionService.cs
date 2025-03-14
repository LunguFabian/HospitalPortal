using HospitalPortal.WEB.Models;

namespace HospitalPortal.WEB.Services
{
	public interface IPrescriptionService
	{
		public Task<List<PrescriptionDto>> GetPrescriptionsByPatientIdAsync(int patientId);
		public Task<bool> CreatePrescriptionAsync(PrescriptionCreate prescriptionCreateModel);
		public Task<List<PrescriptionDto>> GetPrescriptionsByPatientAndDoctorIdAsync(int patientId, int doctorId);
	}
}
