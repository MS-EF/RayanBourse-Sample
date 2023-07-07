using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.EF.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllWithUserName(string userName = "")
        {

            var query = _context.Products.AsNoTracking().Include(q => q.AppUser).AsQueryable();
            if (!string.IsNullOrEmpty(userName))
                query = query.Where(q => q.AppUser.UserName.ToLower().Contains(userName.ToLower()));
            return await query.ToListAsync();
        }

        public async Task<string> GetOwnerId(int productId)
        {
            return (await _context.Products.Select(q => new { q.AppUserId, q.ID }).FirstOrDefaultAsync(q => q.ID == productId)).AppUserId;
        }
    }
}
