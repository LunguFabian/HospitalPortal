using HospitalPortal.Core.Entities;
using HospitalPortal.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPortal.Data.Repositories
{
	public class MedicationRepository : IMedicationRepository
	{
		private readonly HospitalPortalDbContext _hospitalDbContext;
		public MedicationRepository(HospitalPortalDbContext hospitalDbContext)
		{
			_hospitalDbContext = hospitalDbContext;
		}
		public List<Medications> GetMedications()
		{
			return _hospitalDbContext.Medications.ToList();
		}
	}
}
