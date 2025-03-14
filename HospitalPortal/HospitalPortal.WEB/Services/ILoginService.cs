using HospitalPortal.WEB.Models;

namespace HospitalPortal.WEB.Services
{
	public interface ILoginService
	{
		public Task<LoginResult> HandleLoginAsync(LoginRequest loginRequest);
	}
}
