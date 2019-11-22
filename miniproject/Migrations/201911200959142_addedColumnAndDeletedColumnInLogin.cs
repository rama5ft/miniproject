namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedColumnAndDeletedColumnInLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "UserName", c => c.String());
            DropColumn("dbo.Logins", "EmailId");
            DropColumn("dbo.Logins", "SapId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "SapId", c => c.String());
            AddColumn("dbo.Logins", "EmailId", c => c.String());
            DropColumn("dbo.Logins", "UserName");
        }
    }
}
