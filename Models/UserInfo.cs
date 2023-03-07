using System;
using System.Collections.Generic;

#nullable disable

namespace Task1.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            Employees = new HashSet<Employee>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
