using AutoMapper;
using Store.Application.Helper;
using Store.Domain.Entity;
using Store.Domain.Service;
using Store.Domain.UOW;
using static Store.Helper.Enumerations;

namespace Store.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

    }
}
