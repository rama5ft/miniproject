namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DoctorViewModels", "DoctorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DoctorViewModels", "DoctorId", c => c.Int());
        }
    }
}
