namespace HospitalPortal.WEB.Models
{
	public class AppointmentCreate
	{
		public int PatientId { get; set; }
		public int DoctorId { get; set; }
		public DateTime DateAndHour { get; set; }
		public int StatusId { get; set; }
	}
}
