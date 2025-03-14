namespace HospitalPortal.API.Models
{
	public class PatientCreate
	{
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Email { get; set; }
		public string CNP { get; set; }
		public string Password { get; set; }
	}
}
