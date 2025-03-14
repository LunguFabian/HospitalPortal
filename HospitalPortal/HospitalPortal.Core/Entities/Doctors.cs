using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPortal.Core.Entities
{
	public class Doctors
	{
		public int Id { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Email { get; set; }
		public string DoctorCode { get; set; }
		public int SpecializationId { get; set; }
		public string PasswordHash { get; set; }
		public Specializations Specialization { get; set; }
	}
}
