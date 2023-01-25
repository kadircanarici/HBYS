using HBYS.Models;
using HBYS.Repository.Shared.Concrete;
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
        IRepository <Patient> Patient { get; }
        IRepository<Clinic> Clinic { get; }
        IRepository <Doctor> Doctor { get; }


        void Save();

    }
}
