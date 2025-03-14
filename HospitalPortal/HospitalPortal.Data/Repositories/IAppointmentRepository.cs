using HospitalPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPortal.Data.Repositories
{
	public interface IAppointmentRepository
	{
		List<Appointments> GetAppointments();
		List<Appointments> GetAppointmentsByPatientId(int patientId);
		List<Appointments> GetAppointmentsByDoctorId(int doctorId);
		void AddAppointment(Appointments appointment);
		void UpdateAppointmentStatus(Appointments appointment);
		void DeleteAppointment(int id);
		Appointments? GetAppointmentById(int id);
	}
}
