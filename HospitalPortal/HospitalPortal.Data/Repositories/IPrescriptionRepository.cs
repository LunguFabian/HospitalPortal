using HospitalPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPortal.Data.Repositories
{
	public interface IPrescriptionRepository
	{
		public List<Prescriptions> GetPrescriptions();
		void CreatePrescription(Prescriptions prescription);
		void AddMedicationToPrescription(Prescription_Medication prescriptionMedication);
		List<Prescriptions> GetPrescriptionsByPatientId(int patientId);
		List<Prescription_Medication> GetMedicationsByPrescriptionId(int prescriptionId);
		public List<Prescriptions> GetPrescriptionsByPatientAndDoctorId(int patientId, int doctorId);
	}
}
