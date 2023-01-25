using HBYS.Data;
using HBYS.Models;
using HBYS.Repository.Abstract;
using HBYS.Repository.Concrete;
using HBYS.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBYS.Repository.Shared.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            User = new Repository<User>(_db);
            Clinic= new Repository<Clinic>(_db);
            Doctor= new DoctorRepository(_db);
            Patient = new PatientRepository(_db);
        }

        public IRepository<Clinic> Clinic { get; private set; }

        public IDoctorRepository Doctor { get; private set; }

        public IRepository<User> User { get; private set; }

        public IPatientRepository Patient { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
