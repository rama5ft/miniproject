namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedpasswordinpatienttable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Password", c => c.String());
        }
    }
}
