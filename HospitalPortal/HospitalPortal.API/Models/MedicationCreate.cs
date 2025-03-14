namespace HospitalPortal.API.Models
{
	public class MedicationCreate
	{
		public int MedicationId { get; set; }
		public string Dosage { get; set; }
		public string Instructions { get; set; }
	}
}
