using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTO.Product;
using Store.Application.DTO.User;
using Store.Domain.Service;
using static Store.Helper.Enumerations;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Helpers.FilterHandlers.Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly AuthenticatedUserDTO? _loggedInUser;

        public ProductController(IMapper mapper,
            IHttpContextAccessor accessor,
            IProductService productService)
        {
            _mapper = mapper;
            _loggedInUser = (AuthenticatedUserDTO?)accessor?.HttpContext?.Items["User"];
            _productService = productService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto product)
        {
            var productEntity = _mapper.Map<Store.Domain.Entity.Product>(product);

            await _productService.CreateProduct(productEntity);

            return new JsonResult(productEntity);
        }

        [HttpPost("update/status")]
        public async Task<IActionResult> CountProducts([FromBody] ProductDto product)
        {
            if (product.Id == null || product.Id == Guid.Empty)
            {
                return BadRequest();
            }

            var count = await _productService.ChangeProductStatus(product.Id.Value, (ProductStatus)product.Status);

            return new JsonResult(count);
        }

        [HttpPost("count")]
        public async Task<IActionResult> CountProducts([FromBody] List<int> productStatusList)
        {
            var count =  await _productService.GetProductCountByStatus(productStatusList);

            return new JsonResult(count);
        }

        
    }
}
