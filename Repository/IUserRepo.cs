using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Models;

namespace Task1.Repository
{
    public interface IUserRepo
    {
        public List<UserEmp> Login(LoginRequest user);

    }
}
