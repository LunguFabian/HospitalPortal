using HospitalPortal.Core.Entities;
using HospitalPortal.Data.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPortal.Data.Repositories
{
	public class PrescriptionRepository : IPrescriptionRepository
	{
		private readonly HospitalPortalDbContext _hospitalDbContext;
		public PrescriptionRepository(HospitalPortalDbContext hospitalDbContext)
		{
			_hospitalDbContext = hospitalDbContext;
		}
		public List<Prescriptions> GetPrescriptions()
		{
			return _hospitalDbContext.Prescriptions
				.Include(p => p.Patient)
				.Include(p => p.Doctor)
				.ToList();
		}
		public void CreatePrescription(Prescriptions prescription)
		{
			_hospitalDbContext.Prescriptions.Add(prescription);
			_hospitalDbContext.SaveChanges();
		}

		public void AddMedicationToPrescription(Prescription_Medication prescriptionMedication)
		{
			_hospitalDbContext.Prescription_Medication.Add(prescriptionMedication);
			_hospitalDbContext.SaveChanges();
		}

		public List<Prescriptions> GetPrescriptionsByPatientId(int patientId)
		{
			return _hospitalDbContext.Prescriptions
				.Include(p => p.Patient)
				.Include(p => p.Doctor)
				.Where(p => p.PatientId == patientId)
				.ToList();
		}

		public List<Prescriptions> GetPrescriptionsByPatientAndDoctorId(int patientId,int doctorId)
		{
			return _hospitalDbContext.Prescriptions
				.Include(p => p.Patient)
				.Include(p => p.Doctor)
				.Where(p => p.PatientId == patientId && p.DoctorId==doctorId)
				.ToList();
		}

		public List<Prescription_Medication> GetMedicationsByPrescriptionId(int prescriptionId)
		{
			return _hospitalDbContext.Prescription_Medication
				.Include(pm => pm.Medication)
				.Where(pm => pm.PrescriptionId == prescriptionId)
				.ToList();
		}
	}
}
