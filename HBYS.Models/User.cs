using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBYS.Models
{
    [Table("Users")]
    public class User:ModelBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
