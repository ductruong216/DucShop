using System;

namespace ShopOnline.Data.Parttern
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private ShopDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        private ShopDbContext DbContext { get { return dbContext ?? (dbContext = dbFactory.Init()); } }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}