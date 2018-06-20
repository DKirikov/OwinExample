using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinExample.Controllers.AccountController.Structures
{
    public class AuthData
    {
        public AuthData(string email)
        {
            Email = email;
            ValidTime = DateTime.UtcNow + TimeSpan.FromDays(1.0);
            Role = "admin";
        }

        public bool IsValid()
        {
            return ValidTime >= DateTime.UtcNow;
        }

        public void Extend()
        {
            ValidTime = DateTime.UtcNow + TimeSpan.FromDays(1.0);
        }

        public string Email;
        public DateTime ValidTime;
        public string Role;
    }
}