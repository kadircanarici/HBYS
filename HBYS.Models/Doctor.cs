using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBYS.Models
{
    [Table("Doctors")]
    public class Doctor:ModelBase
    {
        public string? Name { get; set; }

        
        public virtual Clinic Clinic { get; set; }
        public Guid ClinicId { get; set; }
        
    }
}
