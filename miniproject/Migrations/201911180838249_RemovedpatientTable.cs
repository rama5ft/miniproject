namespace miniproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedpatientTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Patients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        EmailId = c.String(),
                        SapId = c.Int(nullable: false),
                        Password = c.String(),
                        Age = c.Int(nullable: false),
                        MobileNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
