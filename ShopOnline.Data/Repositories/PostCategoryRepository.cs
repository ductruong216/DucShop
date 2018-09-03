using ShopOnline.Data.Parttern;
using ShopOnline.Model.Models;
using System.Collections.Generic;

namespace ShopOnline.Data.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory>
    {
     
    }

    public class PostCategoryRepository : BaseRepository<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}