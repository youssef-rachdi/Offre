namespace Offre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileCV : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyForJob1", "UploadFile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplyForJob1", "UploadFile");
        }
    }
}
