using HospitalPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPortal.Data.Repositories
{
	public interface IDoctorRepository
	{
		List<Doctors> GetDoctors();
		Doctors GetDoctorById(int id);
		Doctors GetDoctorByEmailAndCode(string email, string doctorCode);
	}
}
