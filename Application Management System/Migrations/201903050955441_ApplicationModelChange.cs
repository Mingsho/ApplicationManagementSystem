namespace Application_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationModelChange : DbMigration
    {
        public override void Up()
        {

            DropForeignKey("dbo.ApplicationApplicant", "Application_ApplicationID", "dbo.Application");
            DropForeignKey("dbo.ApplicationApplicant", "Applicant_ApplicantID", "dbo.Applicant");
            DropForeignKey("dbo.Course", "Application_ApplicationID", "dbo.Application");
            DropIndex("dbo.Course", new[] { "Application_ApplicationID" });
            DropIndex("dbo.ApplicationApplicant", new[] { "Application_ApplicationID" });
            DropIndex("dbo.ApplicationApplicant", new[] { "Applicant_ApplicantID" });
            CreateIndex("dbo.Application", "ApplicantID");
            CreateIndex("dbo.Application", "CourseID");
            AddForeignKey("dbo.Application", "ApplicantID", "dbo.Applicant", "ApplicantID", cascadeDelete: true);
            AddForeignKey("dbo.Application", "CourseID", "dbo.Course", "CourseID", cascadeDelete: true);
            DropColumn("dbo.Course", "Application_ApplicationID");
            DropTable("dbo.ApplicationApplicant");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationApplicant",
                c => new
                    {
                        Application_ApplicationID = c.Int(nullable: false),
                        Applicant_ApplicantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Application_ApplicationID, t.Applicant_ApplicantID });
            
            AddColumn("dbo.Course", "Application_ApplicationID", c => c.Int());
            DropForeignKey("dbo.Application", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Application", "ApplicantID", "dbo.Applicant");
            DropIndex("dbo.Application", new[] { "CourseID" });
            DropIndex("dbo.Application", new[] { "ApplicantID" });
            CreateIndex("dbo.ApplicationApplicant", "Applicant_ApplicantID");
            CreateIndex("dbo.ApplicationApplicant", "Application_ApplicationID");
            CreateIndex("dbo.Course", "Application_ApplicationID");
            AddForeignKey("dbo.Course", "Application_ApplicationID", "dbo.Application", "ApplicationID");
            AddForeignKey("dbo.ApplicationApplicant", "Applicant_ApplicantID", "dbo.Applicant", "ApplicantID", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationApplicant", "Application_ApplicationID", "dbo.Application", "ApplicationID", cascadeDelete: true);
        }
    }
}
