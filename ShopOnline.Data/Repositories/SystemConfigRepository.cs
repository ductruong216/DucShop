using ShopOnline.Data.Parttern;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Repositories
{
    public interface ISystemConfigRepository
    {
    }

    public class SystemConfigRepository : BaseRepository<SystemConfig>, ISystemConfigRepository
    {
        public SystemConfigRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}