using ShopOnline.Data.Parttern;
using ShopOnline.Model.Models;

namespace ShopOnline.Data.Repositories
{
    public interface ISlideRepository
    {
    }

    public class SlideRepository : BaseRepository<Slide>, ISlideRepository
    {
        public SlideRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}