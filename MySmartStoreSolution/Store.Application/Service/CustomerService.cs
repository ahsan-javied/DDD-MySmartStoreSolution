using AutoMapper;
using Store.Application.Helper;
using Store.Domain.Entity;
using Store.Domain.Service;
using Store.Domain.UOW;
using static Store.Helper.Enumerations;

namespace Store.Application.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCustomer(Customer customer)
        {
            await _unitOfWork.CustomerRepository.Add(customer);
            await _unitOfWork.Save();
        }
    }
}
