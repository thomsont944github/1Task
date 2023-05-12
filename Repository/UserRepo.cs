using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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

        public List<DocumentData> GetDocuments()
        {
            var documentlist = _context.DocumentData.Where(x => x.DocPath != "").ToList();
            foreach (var item in documentlist)
            {
                item.DocPath = item.DocPath.Trim();
            }
            return documentlist;
        }
        public List<DocumentData> GetFilePath(string DocName)
        {
            var A = (from d in _context.DocumentData
                     select new DocumentData
                     {
                         DocPath = d.DocPath
                     }).ToList();
            A = _context.DocumentData.Where(x => x.DocName == DocName).ToList();
            foreach (var item in A)
            {
                item.DocPath = item.DocPath.Trim();
            }          
            return A;
        }

        public List<UserEmp> Login(LoginRequest user)
        {
            var a = (from u in _context.UserInfos
                     join e in _context.Employees on u.UserId equals e.UserId
                     where u.Username== user.Username && u.Password == user.Password
                // A = A.Where(u => u.Username == Username && u.Password == Password).ToList();
            select new UserEmp
                     {
                         EmpId = e.EmpId,
                         EmpName = e.EmpName,
                         EmpAdress = e.EmpAdress
                     }).ToList();
            return a;  
        }

        public async Task<DocumentData> AddDoc(DocumentData documentData)
        {
            try
            {
                var result = await _context.DocumentData.AddAsync(documentData);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }           
        } 
        public async Task<DocumentData> DeleteDoc(int DocId)
        {
            var result = await _context.DocumentData.Where(x => x.DocId == DocId).SingleOrDefaultAsync();
            var result2 = _context.DocumentData.Remove(result);
            await _context.SaveChangesAsync();
            return result2.Entity;
        }
        /*public async Task<DocumentData> DeleteDoc(int DocId)
       {
           var result = _context.DocumentData.Find(DocId);
           await _context.SaveChangesAsync();

           return result.Entity;
       }*/
        /*public async Task<SignUp> Register(SignUp Reg)
        {
            var result = await _myContext.SignUps.AddAsync(Reg);
            await _myContext.SaveChangesAsync();
            return result.Entity;
        }*/

    }
}
