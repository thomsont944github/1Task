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
        public async Task<DocumentDataVM> AddDoc(DocumentData documentData)
        {
            var A = await _userRepo.AddDoc(documentData);
            return _mapper.Map<DocumentDataVM>(A);
        }
        /*public async Task<SignUpVM> Register(SignUpVM Reg)
        {
            var list = await _BusBookingRepository.Register(_mapper.Map<SignUp>(Reg));
            return _mapper.Map<SignUpVM>(list);
        }*/
        public async Task<DocumentDataVM> DeleteDoc(int DocId)
        {
            var A = await _userRepo.DeleteDoc(DocId);
            return _mapper.Map<DocumentDataVM>(A);
        }
        public List<DocumentDataVM> GetDocuments()
        {
            List<DocumentData> list = _userRepo.GetDocuments();
            return _mapper.Map<List<DocumentDataVM>>(list);
        }

        public List<DocumentDataVM> GetFilePath(string DocName)
        {
            List<DocumentData> list = _userRepo.GetFilePath(DocName);
            return _mapper.Map<List<DocumentDataVM>>(list);
        }



    }
}
