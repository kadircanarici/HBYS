using HBYS.Models;
using HBYS.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBYS.Repository.Shared.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<User> User { get; }
        IPatientRepository Patient { get; }
        IRepository<Clinic> Clinic { get; }
        IDoctorRepository Doctor { get; }
        
       
      
       
    }
}
