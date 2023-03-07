using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Models;
//using Task1.Repository.Interface;

namespace Task1.Repository
{

    public class UserRepo:IUserRepo
    {
        private readonly Task1Context _context;
        

        public UserRepo(Task1Context context)
        {
            _context = context;
        }

        public List<UserEmp> Login(LoginRequest user)
        {
            //// first check user in user table
            //bool userexists = true;
            //if (userexists)
            //{
            //    // select * from employees table
            //}
            //else
            //{
            //    return 
            //}


            var a = (from u in _context.UserInfos
                     join e in _context.Employees on u.UserId equals e.UserId
                     where u.Username== user.Username && u.Password == user.Password
                     select new UserEmp
                     {
                         EmpId = e.EmpId,
                         EmpName = e.EmpName,
                         EmpAdress = e.EmpAdress
                     }).ToList();
            return a;
            /* var A = (from u in _context.UserInfos
                     join e in _context.Employees on u.UserId equals e.UserId

                     select new UserEmp
                     {
                         EmpId = e.EmpId,
                         EmpName = e.EmpName,
                         EmpAdress = e.EmpAdress
                     }).ToList();
            A = A.Where(u => u.Username == Username && u.Password == Password).ToList();

            return A;*/


        }



    }
}
