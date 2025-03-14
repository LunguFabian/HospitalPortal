using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPortal.Core.Entities
{
	public class Appointments
	{
		public int Id { get; set; }
		public int PatientId { get; set; }
		public Patients Patient { get; set; }
		public int DoctorId { get; set; }
		public Doctors Doctor { get; set; }
		public DateTime DateAndHour { get; set; }
		public int StatusId { get; set; }
		public Statuses Status { get; set; }
	}
}
