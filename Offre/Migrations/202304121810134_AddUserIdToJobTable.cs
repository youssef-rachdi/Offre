namespace Offre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToJobTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Userid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Userid");
        }
    }
}
