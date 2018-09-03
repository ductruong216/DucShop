namespace ShopOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ProductCategories", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.PostCategories", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Posts", "CreatedDate", c => c.DateTime());
            DropColumn("dbo.Products", "CreateDate");
            DropColumn("dbo.ProductCategories", "CreateDate");
            DropColumn("dbo.PostCategories", "CreateDate");
            DropColumn("dbo.Posts", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "CreateDate", c => c.DateTime());
            AddColumn("dbo.PostCategories", "CreateDate", c => c.DateTime());
            AddColumn("dbo.ProductCategories", "CreateDate", c => c.DateTime());
            AddColumn("dbo.Products", "CreateDate", c => c.DateTime());
            DropColumn("dbo.Posts", "CreatedDate");
            DropColumn("dbo.PostCategories", "CreatedDate");
            DropColumn("dbo.ProductCategories", "CreatedDate");
            DropColumn("dbo.Products", "CreatedDate");
        }
    }
}
