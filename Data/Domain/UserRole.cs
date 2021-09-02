using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDemo.Repositories;

namespace AppDemo.Data.Domain
{
    public class UserRole : BaseEntity
    {
        public virtual List<User> User { get; set; }
    }
}
