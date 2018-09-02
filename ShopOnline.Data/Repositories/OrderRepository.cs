using ShopOnline.Data.Parttern;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Repositories
{
    public interface IOrderRepository
    {
    }

    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}