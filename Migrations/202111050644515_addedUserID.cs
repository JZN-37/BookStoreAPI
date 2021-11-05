namespace BookStoreAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "UserID");
        }
    }
}
