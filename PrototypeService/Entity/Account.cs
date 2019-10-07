using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrototypeService.Entity
{
    public class Account
    {
        public string UserName { get; set; }

        public string JobNumber { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
