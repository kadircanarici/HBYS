using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBYS.Models
{
    [Table("Patients")]
    public class Patient:ModelBase
    {
        [MaxLength(11)]
        public string TC { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
