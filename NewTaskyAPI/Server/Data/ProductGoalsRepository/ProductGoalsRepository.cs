using NewTaskyAPI.Shared;

namespace NewTaskyAPI.Server.Data.ProductGoalsRepository
{
    public class ProductGoalsRepository : GenericRepository<ProductGoal>, IProductGoalsRepository
    {
        private readonly AppDbContext _context;

        public ProductGoalsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
