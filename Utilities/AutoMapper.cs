using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Models;
using Task1.ViewModel;

namespace Task1.Utilities
{
    public class AutoMapper: Profile
    {
         public AutoMapper()
        {
            CreateMap<UserEmp, UserEmpVM>().ReverseMap();
            CreateMap<DocumentData, DocumentDataVM>().ReverseMap();

        }
    }
}
