namespace Offre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyJob : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplyForJob1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ApplyDate = c.DateTime(nullable: false),
                        Jobid = c.String(),
                        Userid = c.String(maxLength: 128),
                        Job_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Job_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Userid)
                .Index(t => t.Userid)
                .Index(t => t.Job_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyForJob1", "Userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplyForJob1", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.ApplyForJob1", new[] { "Job_Id" });
            DropIndex("dbo.ApplyForJob1", new[] { "Userid" });
            DropTable("dbo.ApplyForJob1");
        }
    }
}
