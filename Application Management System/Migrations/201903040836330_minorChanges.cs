namespace Application_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minorChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applicant", "Application_ApplicationID", "dbo.Application");
            DropIndex("dbo.Applicant", new[] { "Application_ApplicationID" });
            CreateTable(
                "dbo.ApplicationApplicant",
                c => new
                    {
                        Application_ApplicationID = c.Int(nullable: false),
                        Applicant_ApplicantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Application_ApplicationID, t.Applicant_ApplicantID })
                .ForeignKey("dbo.Application", t => t.Application_ApplicationID, cascadeDelete: true)
                .ForeignKey("dbo.Applicant", t => t.Applicant_ApplicantID, cascadeDelete: true)
                .Index(t => t.Application_ApplicationID)
                .Index(t => t.Applicant_ApplicantID);
            
            DropColumn("dbo.Applicant", "Application_ApplicationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applicant", "Application_ApplicationID", c => c.Int());
            DropForeignKey("dbo.ApplicationApplicant", "Applicant_ApplicantID", "dbo.Applicant");
            DropForeignKey("dbo.ApplicationApplicant", "Application_ApplicationID", "dbo.Application");
            DropIndex("dbo.ApplicationApplicant", new[] { "Applicant_ApplicantID" });
            DropIndex("dbo.ApplicationApplicant", new[] { "Application_ApplicationID" });
            DropTable("dbo.ApplicationApplicant");
            CreateIndex("dbo.Applicant", "Application_ApplicationID");
            AddForeignKey("dbo.Applicant", "Application_ApplicationID", "dbo.Application", "ApplicationID");
        }
    }
}
