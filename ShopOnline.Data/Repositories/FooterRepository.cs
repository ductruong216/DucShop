using ShopOnline.Data.Parttern;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Repositories
{
    public interface IFooterRepository : IRepository<Footer>
    {

    }
    public class FooterRepository : BaseRepository<Footer>, IFooterRepository
    {
        public FooterRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
    }
}