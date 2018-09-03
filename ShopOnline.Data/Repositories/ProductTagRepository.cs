using ShopOnline.Data.Parttern;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Repositories
{
    public interface IProducTagRepository : IRepository<ProductTag>
    {
    }

    public class ProductTagRepository : BaseRepository<ProductTag>, IProducTagRepository
    {
        public ProductTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}