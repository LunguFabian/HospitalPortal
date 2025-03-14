using HospitalPortal.WEB.Models;

namespace HospitalPortal.WEB.Services
{
	public interface IMedicationService
	{
		public Task<List<MedicationDto>> GetMedicationsAsync();
	}
}
