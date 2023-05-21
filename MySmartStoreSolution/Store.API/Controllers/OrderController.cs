using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTO.Order;
using Store.Application.DTO.User;
using Store.Domain.Entity;
using Store.Domain.Service;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Helpers.FilterHandlers.Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly AuthenticatedUserDTO? _loggedInUser;

        public OrderController(IMapper mapper,
            IHttpContextAccessor accessor,
            IOrderService orderService,
            IUserService userService)
        {
            _mapper = mapper;
            _loggedInUser = (AuthenticatedUserDTO?)accessor?.HttpContext?.Items["User"];
            _orderService = orderService;
            _userService = userService;
        }


        [HttpPost("submitted")]
        public async Task<IActionResult> OrderPlaced([FromBody] PlaceOrderDto orderDto)
        {
            var oItems = _mapper.Map<List<OrderItem>>(orderDto.OrderItems);

            var result = await _orderService.PlaceOrder(orderDto.CustomerId, oItems);

            if (result != null)
            {
                //Order placed successfully.
                return new JsonResult(new { result });
            }

            return BadRequest("Failed to place the order.");
        }
    }
}
