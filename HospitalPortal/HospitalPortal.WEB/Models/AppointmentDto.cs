using HospitalPortal.Core.Entities;

namespace HospitalPortal.WEB.Models
{
	public class AppointmentDto
	{
		public int Id { get; set; }
		public string PatientName { get; set; }
		public string DoctorName { get; set; }
		public DateTime DateAndHour { get; set; }
		public string StatusName { get; set; }
		public int PatientId { get; set; }
	}
}
