namespace Offre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyJobs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplyForJob1", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.ApplyForJob1", new[] { "Job_Id" });
            DropColumn("dbo.ApplyForJob1", "Jobid");
            RenameColumn(table: "dbo.ApplyForJob1", name: "Job_Id", newName: "Jobid");
            AlterColumn("dbo.ApplyForJob1", "Jobid", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplyForJob1", "Jobid", c => c.Int(nullable: false));
            CreateIndex("dbo.ApplyForJob1", "Jobid");
            AddForeignKey("dbo.ApplyForJob1", "Jobid", "dbo.Jobs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyForJob1", "Jobid", "dbo.Jobs");
            DropIndex("dbo.ApplyForJob1", new[] { "Jobid" });
            AlterColumn("dbo.ApplyForJob1", "Jobid", c => c.Int());
            AlterColumn("dbo.ApplyForJob1", "Jobid", c => c.String());
            RenameColumn(table: "dbo.ApplyForJob1", name: "Jobid", newName: "Job_Id");
            AddColumn("dbo.ApplyForJob1", "Jobid", c => c.String());
            CreateIndex("dbo.ApplyForJob1", "Job_Id");
            AddForeignKey("dbo.ApplyForJob1", "Job_Id", "dbo.Jobs", "Id");
        }
    }
}
