using Microsoft.EntityFrameworkCore;
using HospitalPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalPortal.Data.DbContext
{
	public class HospitalPortalDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public DbSet<Patients> Patients { get; set; }
		public DbSet<Doctors> Doctors { get; set; }
		public DbSet<Appointments> Appointments { get; set; }
		public DbSet<Prescriptions> Prescriptions { get; set; }
		public DbSet<Prescription_Medication> Prescription_Medication { get; set; }
		public DbSet<Medications> Medications { get; set; }
		public DbSet<Specializations> Specializations { get; set; }
		public DbSet<Statuses> Statuses { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("");
		}
	}
}
