using ShopOnline.Data.Parttern;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Repositories
{
    public interface IOrderDetailRepository
    {
    }

    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}