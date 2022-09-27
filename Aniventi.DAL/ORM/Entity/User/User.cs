using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aniventi.DAL.ORM.Entity
{
    public class User : BaseEntity
    {
        public string EMail { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }

        public DateTime? RefreshTokenDate { get; set; }
    }
}
