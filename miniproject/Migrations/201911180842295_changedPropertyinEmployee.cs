namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedPropertyinEmployee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "SapId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "SapId", c => c.Int(nullable: false));
        }
    }
}
