namespace Offre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCondidatsViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConadidatsViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        UploadFile = c.String(),
                        ApplyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConadidatsViewModels");
        }
    }
}
