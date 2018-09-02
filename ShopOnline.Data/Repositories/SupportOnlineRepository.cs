using ShopOnline.Data.Parttern;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Repositories
{
    public interface ISupportOnlineRepository
    {
    }

    internal class SupportOnlineRepository : BaseRepository<SupportOnline>, ISupportOnlineRepository
    {
        public SupportOnlineRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}