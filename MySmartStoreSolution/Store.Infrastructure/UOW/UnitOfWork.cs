
using Microsoft.Extensions.Configuration;
using Store.Domain.Repository;
using Store.Domain.UOW;
using Store.Infrastructure.DBCore;
using Store.Infrastructure.Repository;

namespace Store.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private CoreDBContext _dbContext;
        public UnitOfWork(CoreDBContext context)
        {
            _dbContext = context;
        }

        private IUserRepository userRepository;
        private ICustomerRepository customerRepository;
        private IOrderRepository orderRepository;
        private IOrderItemRepository orderItemRepository;
        private IProductRepository productRepository;
        private IProductCategoryRepository productCategoryRepository;


        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_dbContext);
                }
                return userRepository;
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new CustomerRepository(_dbContext);
                }
                return customerRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(_dbContext);
                }
                return orderRepository;
            }
        }

        public IOrderItemRepository OrderItemRepository
        {
            get
            {
                if (orderItemRepository == null)
                {
                    orderItemRepository = new OrderItemRepository(_dbContext);
                }
                return orderItemRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(_dbContext);
                }
                return productRepository;
            }
        }

        public IProductCategoryRepository ProductCategoryRepository
        {
            get
            {
                if (productCategoryRepository == null)
                {
                    productCategoryRepository = new ProductCategoryRepository(_dbContext);
                }
                return productCategoryRepository;
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



    }
}
