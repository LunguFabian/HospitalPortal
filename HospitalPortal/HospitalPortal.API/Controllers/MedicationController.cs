using HospitalPortal.API.Models;
using HospitalPortal.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using HospitalPortal.Core.Entities;
namespace HospitalPortal.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MedicationController : ControllerBase
	{
		private readonly IMedicationRepository _medicationRepository;
		public MedicationController(IMedicationRepository medicationRepository)
		{
			_medicationRepository = medicationRepository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<MedicationDto>> GetMedications()
		{
			var medications = _medicationRepository.GetMedications();
			var medicationDtos = medications.Select(m => new MedicationDto
			{
				MedicationId = m.Id,
				MedicationName = m.Name,
				Dosage = null,
				Instructions = null
			}).ToList();

			return Ok(medicationDtos);
		}
	}
}
