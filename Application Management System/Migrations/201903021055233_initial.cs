namespace Application_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgentRepresentative",
                c => new
                    {
                        AgentRepresentativeID = c.Int(nullable: false, identity: true),
                        FirstMidName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(maxLength: 60),
                        ContactNumber = c.String(maxLength: 20),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.AgentRepresentativeID);
            
            CreateTable(
                "dbo.Agent",
                c => new
                    {
                        AgentID = c.Int(nullable: false, identity: true),
                        LegalName = c.String(maxLength: 120),
                        TradingName = c.String(nullable: false),
                        EmailAddress = c.String(),
                        ContactNumber = c.String(maxLength: 20),
                        ContactPerson = c.String(maxLength: 60),
                        AgentApplicationForm = c.Boolean(nullable: false),
                        CompanyRegistration = c.Boolean(nullable: false),
                        Agreement = c.Boolean(nullable: false),
                        AgreementSignedDate = c.DateTime(),
                        CompanyProfile = c.Boolean(nullable: false),
                        ReportedToAsqa = c.Boolean(nullable: false),
                        AgentRepresentativeID = c.Int(nullable: false),
                        StaffID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AgentID)
                .ForeignKey("dbo.AgentRepresentative", t => t.AgentRepresentativeID, cascadeDelete: true)
                .ForeignKey("dbo.Staff", t => t.StaffID, cascadeDelete: true)
                .Index(t => t.AgentRepresentativeID)
                .Index(t => t.StaffID);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        StaffID = c.Int(nullable: false, identity: true),
                        FirstMidName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.StaffID);
            
            CreateTable(
                "dbo.Applicant",
                c => new
                    {
                        ApplicantID = c.Int(nullable: false, identity: true),
                        SecondaryID = c.Int(nullable: false),
                        FirstMidName = c.String(nullable: false),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Country = c.String(nullable: false),
                        EmailAddress = c.String(),
                        ContactNumber = c.String(),
                        Application_ApplicationID = c.Int(),
                    })
                .PrimaryKey(t => t.ApplicantID)
                .ForeignKey("dbo.Application", t => t.Application_ApplicationID)
                .Index(t => t.Application_ApplicationID);
            
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        ApplicationID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        ProposedStartDate = c.DateTime(nullable: false),
                        ProposedEndDate = c.DateTime(nullable: false),
                        LooIssuedDate = c.DateTime(nullable: false),
                        LooExpiryDate = c.DateTime(nullable: false),
                        AirportPickup = c.Boolean(nullable: false),
                        Accomodation = c.Boolean(nullable: false),
                        Oshc = c.Boolean(nullable: false),
                        AgentID = c.Int(nullable: false),
                        ApplicationStatus = c.Int(nullable: false),
                        MarketingComment = c.String(),
                        DepositReceived = c.Boolean(nullable: false),
                        DepositReceivedDate = c.DateTime(),
                        TuitionFeeReceived = c.Double(nullable: false),
                        MaterialFeeReceived = c.Double(nullable: false),
                        ApplicationFeeReceived = c.Double(nullable: false),
                        OshcFeeReceived = c.Double(nullable: false),
                        OutstandingAmount = c.Double(nullable: false),
                        FinanceComments = c.String(),
                        ApplicationForm = c.Boolean(nullable: false),
                        ApplicationFormReceivedDate = c.DateTime(nullable: false),
                        PreTrainingReview = c.Boolean(nullable: false),
                        PtrCompletedDate = c.DateTime(),
                        AcceptanceOfOffer = c.Boolean(nullable: false),
                        AcceptanceOfOfferDate = c.DateTime(),
                        AcademicTranscripts = c.Boolean(nullable: false),
                        Passport = c.Boolean(nullable: false),
                        IeltsOrEquivalent = c.Boolean(nullable: false),
                        OshcCurrency = c.Boolean(nullable: false),
                        FinancialViability = c.Boolean(nullable: false),
                        CourseOutline = c.Boolean(nullable: false),
                        GteReviewed = c.Boolean(nullable: false),
                        AdministrationComment = c.String(),
                        PreEnrolmentInformation = c.Boolean(nullable: false),
                        EnrolledInSms = c.Boolean(nullable: false),
                        eCoeIssued = c.Boolean(nullable: false),
                        eCoeIssuedDate = c.DateTime(),
                        DepositMatchingLoo = c.Boolean(nullable: false),
                        DatesMatchingLoo = c.Boolean(nullable: false),
                        CoeStatus = c.Int(nullable: false),
                        eCoeLastUpdated = c.DateTime(),
                        RefundRequired = c.Boolean(nullable: false),
                        RefundAmount = c.Double(nullable: false),
                        DateRefundProcessed = c.DateTime(),
                        CoeComment = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationID);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        VetNationalCode = c.String(nullable: false),
                        CourseName = c.String(nullable: false, maxLength: 125),
                        CourseComment = c.String(maxLength: 250),
                        Application_ApplicationID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Application", t => t.Application_ApplicationID)
                .Index(t => t.Application_ApplicationID);
            
            CreateTable(
                "dbo.Pricing",
                c => new
                    {
                        PricingID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        CourseType = c.Int(nullable: false),
                        TuitionFee = c.Double(nullable: false),
                        MaterialFee = c.Double(nullable: false),
                        ApplicationFee = c.Double(nullable: false),
                        PricingComment = c.String(),
                    })
                .PrimaryKey(t => t.PricingID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "Application_ApplicationID", "dbo.Application");
            DropForeignKey("dbo.Pricing", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Applicant", "Application_ApplicationID", "dbo.Application");
            DropForeignKey("dbo.Agent", "StaffID", "dbo.Staff");
            DropForeignKey("dbo.Agent", "AgentRepresentativeID", "dbo.AgentRepresentative");
            DropIndex("dbo.Pricing", new[] { "CourseID" });
            DropIndex("dbo.Course", new[] { "Application_ApplicationID" });
            DropIndex("dbo.Applicant", new[] { "Application_ApplicationID" });
            DropIndex("dbo.Agent", new[] { "StaffID" });
            DropIndex("dbo.Agent", new[] { "AgentRepresentativeID" });
            DropTable("dbo.Pricing");
            DropTable("dbo.Course");
            DropTable("dbo.Application");
            DropTable("dbo.Applicant");
            DropTable("dbo.Staff");
            DropTable("dbo.Agent");
            DropTable("dbo.AgentRepresentative");
        }
    }
}
