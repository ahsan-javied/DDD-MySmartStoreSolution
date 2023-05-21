using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTO.Customer;
using Store.Application.DTO.Product;
using Store.Application.DTO.User;
using Store.Application.Helper;
using Store.Application.Service;
using Store.Domain.Entity;
using Store.Domain.Service;
using Store.Domain.UOW;
using static Store.Helper.Enumerations;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Helpers.FilterHandlers.Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        private readonly AuthenticatedUserDTO? _loggedInUser;

        public CustomerController(IMapper mapper,
            IHttpContextAccessor accessor,
            ICustomerService customerService)
        {
            _mapper = mapper;
            _loggedInUser = (AuthenticatedUserDTO?)accessor?.HttpContext?.Items["User"];
            _customerService = customerService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customer)
        {
            customer.UserId = _loggedInUser.Id.HasValue ? _loggedInUser.Id.Value : 0;
            var customerEntity = _mapper.Map<Customer>(customer);

            await _customerService.CreateCustomer(customerEntity);

            return new JsonResult(customerEntity);
        }
        
    }
}
