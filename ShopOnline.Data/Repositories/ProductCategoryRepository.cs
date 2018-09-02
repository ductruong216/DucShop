using ShopOnline.Data.Parttern;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Repositories
{
    public interface IProductCategoryRepository
    {
    }

    public class ProductCategoryRepository : BaseRepository<Product>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}