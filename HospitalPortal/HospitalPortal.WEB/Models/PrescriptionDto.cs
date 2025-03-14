
namespace HospitalPortal.WEB.Models
{
	public class PrescriptionDto
	{
		public int Id { get; set; }
		public int DoctorId { get; set; }
		public string PatientName { get; set; }
		public string DoctorName { get; set; }
		public List<MedicationDto> Medications { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
