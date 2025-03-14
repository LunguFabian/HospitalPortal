namespace HospitalPortal.API.Models
{
	public class PrescriptionCreate
	{
		public int PatientId { get; set; }
		public int DoctorId { get; set; }
		public List<MedicationCreate> Medications { get; set; }
	}
}
