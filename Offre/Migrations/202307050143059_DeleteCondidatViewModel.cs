namespace Offre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCondidatViewModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ConadidatsViewModels");
        }
        
        public override void Down()
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
    }
}
