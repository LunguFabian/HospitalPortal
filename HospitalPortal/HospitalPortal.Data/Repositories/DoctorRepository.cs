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
	public class DoctorRepository : IDoctorRepository
	{
		private readonly HospitalPortalDbContext _hospitalDbContext;
		public DoctorRepository(HospitalPortalDbContext hospitalDbContext)
		{
			_hospitalDbContext = hospitalDbContext;
		}
		public Doctors GetDoctorByEmailAndCode(string email, string doctorCode)
		{
			return _hospitalDbContext.Doctors.FirstOrDefault(doctor => doctor.Email == email && doctor.DoctorCode == doctorCode);
		}
		public Doctors GetDoctorById(int id)
		{
			return _hospitalDbContext.Doctors.Include(doctor => doctor.Specialization).FirstOrDefault(doctor => doctor.Id == id);
		}
		public List<Doctors> GetDoctors()
		{
			return _hospitalDbContext.Doctors.Include(doctor => doctor.Specialization).ToList();
		}
	}
}
