using ShopOnline.Data.Parttern;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Repositories
{
    public interface IVisitorStatisticRepository
    { }

    public class VisitorStatisticRepository : BaseRepository<VisitorStatistic>, IVisitorStatisticRepository
    {
        public VisitorStatisticRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}