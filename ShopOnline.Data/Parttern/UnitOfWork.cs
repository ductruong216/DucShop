using System;

namespace ShopOnline.Data.Parttern
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private ShopDbContext dbContext;
        private ShopDbContext DbContext { get { return dbContext ?? (dbContext = dbFactory.Init()); } }

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
   
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}