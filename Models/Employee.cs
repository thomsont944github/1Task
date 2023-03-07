using System;
using System.Collections.Generic;

#nullable disable

namespace Task1.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAdress { get; set; }
        public int UserId { get; set; }

        public virtual UserInfo User { get; set; }
    }
}
