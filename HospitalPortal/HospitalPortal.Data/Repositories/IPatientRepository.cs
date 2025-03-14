using HospitalPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPortal.Data.Repositories
{
	public interface IPatientRepository
	{
		List<Patients> GetPatients();
		Patients? GetPatientById(int id);
		Patients GetPatientByEmail(string email);
		void AddPatient(Patients patient);
		void DeletePatient(int id);
		void UpdatePatient(Patients patient);
	}
}
