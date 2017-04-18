namespace MiniFb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonModels", "UserName", c => c.String());
            AddColumn("dbo.PersonModels", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonModels", "Password");
            DropColumn("dbo.PersonModels", "UserName");
        }
    }
}
