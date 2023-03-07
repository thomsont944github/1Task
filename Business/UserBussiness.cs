using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Business.Interface;
using Task1.Models;
using Task1.Repository;
using Task1.ViewModel;

namespace Task1.Business
{
    public class UserBussiness:IUserBusiness
    {
        private readonly IUserRepo _userRepo;

        private readonly IMapper _mapper;
        public UserBussiness(IUserRepo repository, IMapper mapper)
        {
            _userRepo = repository;
            _mapper = mapper;
        }

        public List<UserEmpVM> Login(LoginRequest user)
        {
            var list = _userRepo.Login(user);
            return _mapper.Map<List<UserEmpVM>>(list);
        }

      

    }
}
