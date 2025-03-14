namespace HospitalPortal.WEB.Models
{
	public class LoginRequest
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string? DoctorCode { get; set; }
	}
}
