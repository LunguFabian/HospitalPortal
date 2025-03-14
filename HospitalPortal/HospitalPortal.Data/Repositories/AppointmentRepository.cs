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
	public class AppointmentRepository : IAppointmentRepository
	{
		private readonly HospitalPortalDbContext _hospitalDbContext;
		public AppointmentRepository(HospitalPortalDbContext hospitalDbContext)
		{
			_hospitalDbContext = hospitalDbContext;
		}

		public List<Appointments> GetAppointmentsByPatientId(int patientId)
		{
			var appointments = _hospitalDbContext.Appointments
			.Include(a => a.Patient)
			.Include(a => a.Doctor)
			.Include(a => a.Status)
			.Where(app => app.PatientId == patientId).ToList();
			return appointments;
		}

		public List<Appointments> GetAppointments()
		{
			var appointments = _hospitalDbContext.Appointments
			.Include(a => a.Patient)
			.Include(a => a.Doctor)
			.Include(a => a.Status)
			.ToList();
			return appointments;
		}

		public List<Appointments> GetAppointmentsByDoctorId(int doctorId)
		{
			var appointments = _hospitalDbContext.Appointments
			.Include(a => a.Patient)
			.Include(a => a.Doctor)
			.Include(a => a.Status)
			.Where(app => app.DoctorId == doctorId).ToList();
			return appointments;
		}

		public void AddAppointment(Appointments appointment)
		{
			_hospitalDbContext.Appointments.Add(appointment);
			_hospitalDbContext.SaveChanges();
		}

		public void UpdateAppointmentStatus(Appointments appointment)
		{
			_hospitalDbContext.Appointments.Update(appointment);
			_hospitalDbContext.SaveChanges();
		}

		public void DeleteAppointment(int id)
		{
			var appointment = _hospitalDbContext.Appointments.FirstOrDefault(appointment => appointment.Id == id);
			if (appointment != null)
			{
				_hospitalDbContext.Appointments.Remove(appointment);
				_hospitalDbContext.SaveChanges();
			}
		}

		public Appointments? GetAppointmentById(int id)
		{
			return _hospitalDbContext.Appointments.FirstOrDefault(appointment => appointment.Id == id);
		}

	}
}
