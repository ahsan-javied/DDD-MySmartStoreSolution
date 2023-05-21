using Store.Domain.Entity;
using Store.Domain.Service;
using Store.Domain.UOW;
using static Store.Helper.Enumerations;

namespace Store.Application.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> PlaceOrder(Int64 customerId, List<OrderItem> items)
        {
            // Check if customer exists
            var existingUser = await _unitOfWork.CustomerRepository
               .GetSingleBy(a => !a.IsDeleted && a.Id == customerId);

            if (existingUser == null)
                throw new ArgumentException("Invalid customer ID.");

            // Check if all products are available and in stock
            var prorList = items.Select(a => a.Id).ToList();
            var productList = await _unitOfWork.ProductRepository
                .GetBy(a => !a.IsDeleted && a.Status == (int)ProductStatus.InStock &&
                items.Select(a => a.Id).ToList().Contains(a.Id)
                );

            var raiseError = false;

            if (!productList.Any()) raiseError = true;

            if (!raiseError)
            {
                foreach (var item in items)
                {
                    var prod = productList?.Where(a => a.Id == item.Id)?.FirstOrDefault();
                    if (prod == null || prod.Quantity < prod.Quantity)
                    {
                        raiseError = true;
                        break;
                    }
                }
            }
            if (raiseError)
                throw new ArgumentException("Invalid product or product is not available in sufficient quantity.");


            // Create order and order items
            var order = new Order
            {
                Id = Guid.NewGuid(),
                OrderDate = DateTime.UtcNow,
                CustomerId = customerId,
                Items = items,
                Status = (int)OrderStatus.Placed,
                IsDeleted = false,
                CreatedBy = 1,
                CreatedDate = DateTime.UtcNow,
            };

            // Update product quantities
            foreach (var item in items)
            {
                var product = await _unitOfWork.ProductRepository.GetSingleBy(a=> a.Id == item.ProductId);
                product.Quantity -= item.Quantity;
                product.UpdatedBy = 1;
                product.UpdatedDate = DateTime.UtcNow;

                _unitOfWork.ProductRepository.Edit(product);
            }

            // Save order and commit changes
            await _unitOfWork.OrderRepository.Add(order);
            await _unitOfWork.Save();

            return order;
        }
    }
}