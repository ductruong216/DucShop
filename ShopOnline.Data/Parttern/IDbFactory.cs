namespace ShopOnline.Data.Parttern
{
    public interface IDbFactory
    {
        ShopDbContext Init();
    }
}