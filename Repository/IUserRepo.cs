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
        public List<DocumentData> GetDocuments();
        public List<DocumentData> GetFilePath(string DocName);
        public Task<DocumentData> AddDoc(DocumentData documentData);
        public Task<DocumentData> DeleteDoc(int DocId);
    }
}
