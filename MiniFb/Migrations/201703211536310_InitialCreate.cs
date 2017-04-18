namespace MiniFb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonModels",
                c => new
                    {
                        PersonModelID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Bio = c.String(),
                        Age = c.Int(nullable: false),
                        ImgUrl = c.String(),
                        PersonId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PersonModelID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonModels");
        }
    }
}
