using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Models.Enums
{
    public enum RegistrationStatus
    {
        Success = 1,
        EmailOrUsernameRepeated = 2,
        PasswordRequired = 3,
        Failed = 4
    }
}
