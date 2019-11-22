namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumnSpecialization : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Specialization", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Specialization");
        }
    }
}
