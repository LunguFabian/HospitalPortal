using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPortal.Core.Entities
{
	public class Prescription_Medication
	{
		public int Id { get; set; }
		public int PrescriptionId { get; set; }
		public Prescriptions Prescription { get; set; }
		public int MedicationId { get; set; }
		public Medications Medication { get; set; }
		public string Dosage { get; set; }
		public string Instructions { get; set; }
	}
}
