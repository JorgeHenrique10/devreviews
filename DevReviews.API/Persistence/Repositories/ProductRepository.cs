using System.Collections.Generic;
using System.Threading.Tasks;
using DevReviews.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevReviews.API.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DevReviewsDbContext _dbContext;
        public ProductRepository(DevReviewsDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddReviewAsync(ProductReview productReview)
        {
            await _dbContext.ProductReviews.AddAsync(productReview);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetDetailsByIdAsync(int id)
        {
            return await _dbContext.Products
            .Include(p => p.Reviews)
            .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductReview> GetReviewByIdAsync(int id)
        {
            return await _dbContext.ProductReviews.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
    }
}