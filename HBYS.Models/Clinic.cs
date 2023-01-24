using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBYS.Models
{
    [Table("Clinics")]
    public class Clinic : ModelBase
    {
        public string? Name { get; set; }
       

    }
}
