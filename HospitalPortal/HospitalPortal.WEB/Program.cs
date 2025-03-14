using Blazored.LocalStorage;
using HospitalPortal.Blazor.Services;
using HospitalPortal.WEB.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using System.Globalization;

namespace HospitalPortal.WEB
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");
			builder.RootComponents.Add<HeadOutlet>("head::after");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7058") });
			builder.Services.AddScoped<IPatientService, PatientService>();
			builder.Services.AddScoped<ILoginService, LoginService>();
			builder.Services.AddScoped<IDoctorService, DoctorService>();
			builder.Services.AddScoped<IAppointmentService, AppointmentService>();
			builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
			builder.Services.AddScoped<IMedicationService, MedicationService>();
			builder.Services.AddRadzenComponents();
			builder.Services.AddScoped<DialogService>();
			builder.Services.AddBlazoredLocalStorage();
			builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
			builder.Services.AddAuthorizationCore();
			var host = builder.Build();
			await host.RunAsync();
		}
	}
}
