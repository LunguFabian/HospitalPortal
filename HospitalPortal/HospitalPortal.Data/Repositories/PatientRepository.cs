using HospitalPortal.Core.Entities;
using HospitalPortal.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPortal.Data.Repositories
{
	public class PatientRepository : IPatientRepository
	{
		private readonly HospitalPortalDbContext _hospitalDbContext;
		public PatientRepository(HospitalPortalDbContext hospitalDbContext)
		{
			_hospitalDbContext = hospitalDbContext;
		}

		public void AddPatient(Patients patient)
		{
			_hospitalDbContext.Patients.Add(patient);
			_hospitalDbContext.SaveChanges();
		}

		public void DeletePatient(int id)
		{
			var patient = _hospitalDbContext.Patients.FirstOrDefault(patient => patient.Id == id);
			if (patient != null)
			{
				_hospitalDbContext.Patients.Remove(patient);
				_hospitalDbContext.SaveChanges();
			}
		}

		public Patients GetPatientByEmail(string email)
		{
			return _hospitalDbContext.Patients.FirstOrDefault(patient => patient.Email == email);
		}

		public Patients? GetPatientById(int id)
		{
			return _hospitalDbContext.Patients.FirstOrDefault(patient => patient.Id == id);
		}
		public List<Patients> GetPatients()
		{
			return _hospitalDbContext.Patients.ToList();
		}

		public void UpdatePatient(Patients patient)
		{
			var currentPatient = _hospitalDbContext.Patients.FirstOrDefault(p => p.Id == patient.Id);
			if (currentPatient != null)
			{
				currentPatient.LastName = patient.LastName;
				currentPatient.FirstName = patient.FirstName;
				currentPatient.Email = patient.Email;
				currentPatient.CNP = patient.CNP;
				currentPatient.PasswordHash = patient.PasswordHash;
				_hospitalDbContext.Patients.Update(currentPatient);
				_hospitalDbContext.SaveChanges();
			}
		}
	}
}
