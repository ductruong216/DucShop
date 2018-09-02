using ShopOnline.Data.Parttern;
using ShopOnline.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Repositories
{
    public interface IMenuGroupRepository
    {

    }
  public  class MenuGroupRepository: BaseRepository<MenuGroup>, IMenuGroupRepository
    {
        public MenuGroupRepository(IDbFactory dbFactory): base(dbFactory) { }
    }
}
