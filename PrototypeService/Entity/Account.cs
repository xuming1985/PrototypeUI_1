using System;

namespace PrototypeService.Entity
{
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string JobNumber { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreateUser { get; set; }

    }
}
