namespace BookStoreAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedUserIDIdentity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "UserID", c => c.Int(nullable: false, identity: true));
        }
    }
}
