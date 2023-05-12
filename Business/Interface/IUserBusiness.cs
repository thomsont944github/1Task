using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Models;
using Task1.ViewModel;

namespace Task1.Business.Interface
{
    public interface IUserBusiness
    {
        List<UserEmpVM> Login(LoginRequest user);
        List<DocumentDataVM> GetDocuments();
        List<DocumentDataVM> GetFilePath(string DocName);
        Task<DocumentDataVM> AddDoc(DocumentData documentData);
        Task<DocumentDataVM> DeleteDoc(int DocId);
    }
}
