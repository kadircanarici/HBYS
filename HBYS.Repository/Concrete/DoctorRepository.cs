using HBYS.Data;
using HBYS.Models;
using HBYS.Repository.Abstract;
using HBYS.Repository.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBYS.Repository.Concrete
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly ApplicationDbContext _db;
        public DoctorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
