namespace Application_Management_System.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Application_Management_System.Models;
    using Application_Management_System.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<Application_Management_System.DAL.AmsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Application_Management_System.DAL.AmsContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            context.AgentRepresentatives.AddOrUpdate(a => new { a.FirstMidName, a.LastName },
                new AgentRepresentative()
                {
                    FirstMidName = "Prakash",
                    LastName = "Pandey",
                    ContactNumber = "+97798415489789",
                    EmailAddress = "info@queensford.com"
                },
                new AgentRepresentative()
                {
                    FirstMidName = "Nabindra",
                    LastName = "Gurung",
                    ContactNumber = "+9779841444578",
                    EmailAddress = "info@dolphin.com",
                });

            context.SaveChanges();

            context.Staffs.AddOrUpdate(s => new { s.FirstMidName, s.LastName },
                new Staff()
                {
                    FirstMidName = "Sujan",
                    LastName = "Parajuli"
                },
                new Staff()
                {
                    FirstMidName = "Sylvia",
                    LastName = "Zhang"
                });

            context.SaveChanges();

            context.Agents.AddOrUpdate(a => a.LegalName,
                new Agent()
                {
                    LegalName = "Sealink Australia Pty Ltd",
                    TradingName = "Sealink Australia",
                    EmailAddress = "info@sealink.com",
                    ContactNumber = "0420154578",
                    ContactPerson = "Man Bahadur Acharya",
                    AgentApplicationForm = true,
                    CompanyRegistration = true,
                    Agreement = true,
                    AgreementSignedDate = DateTime.Parse("2019-01-12"),
                    CompanyProfile = true,
                    ReportedToAsqa = true,
                    AgentRepresentativeID = context.AgentRepresentatives.Where(a => a.FirstMidName == "Prakash" && a.LastName == "Pandey").Single().AgentRepresentativeID,
                    StaffID=context.Staffs.Where(s=>s.FirstMidName=="Sujan" && s.LastName=="Parajuli").Single().StaffID

                },
                new Agent()
                {
                    LegalName = "Dolphine Consultancy Pty Ltd",
                    TradingName = "Dolphine Consultancy",
                    EmailAddress = "info@Dolphine.com",
                    ContactNumber = "0420154578",
                    ContactPerson = "Nabindra Gurung",
                    AgentApplicationForm = true,
                    CompanyRegistration = true,
                    Agreement = true,
                    AgreementSignedDate = DateTime.Parse("2018-08-12"),
                    CompanyProfile = true,
                    ReportedToAsqa = true,
                    AgentRepresentativeID = context.AgentRepresentatives.Where(a => a.FirstMidName == "Nabindra" && a.LastName == "Gurung").Single().AgentRepresentativeID,
                    StaffID = context.Staffs.Where(s => s.FirstMidName == "Sylvia" && s.LastName == "Zhang").Single().StaffID
                });
            context.SaveChanges();

            context.Courses.AddOrUpdate(c => c.VetNationalCode,
                new Course()
                {
                    VetNationalCode = "BSB50215",
                    CourseName = "Diploma of Business",
                    CourseComment = "Diploma of Business"
                },
                new Course()
                {
                    VetNationalCode = "BSB60215",
                    CourseName = "Advanced Diploma of Business",
                    CourseComment = "Advanced Diploma of Business"
                });
            context.SaveChanges();

            context.Pricings.AddOrUpdate(p => new { p.CourseID, p.CourseType },
                new Pricing()
                {
                    CourseID = context.Courses.Where(c => c.VetNationalCode == "BSB50215").Single().CourseID,
                    CourseType = CourseType.Offshore,
                    TuitionFee = 10000,
                    MaterialFee = 250,
                    ApplicationFee = 250,
                    PricingComment = "Offshore Business price."
                });
            context.SaveChanges();

            context.Applicants.AddOrUpdate(a => new { a.SecondaryID },
                new Applicant()
                {
                    SecondaryID = 1,
                    FirstMidName = "Ronish",
                    LastName = "Pradhan",
                    DateOfBirth = DateTime.Parse("1998-02-25"),
                    Country = "Nepal",
                    EmailAddress = "ronish@gmail.com",
                    ContactNumber = "+9779841125456"
                },
                new Applicant()
                {
                    SecondaryID=2,
                    FirstMidName = "Devi",
                    LastName = "Khadka",
                    DateOfBirth = DateTime.Parse("1999-12-25"),
                    Country = "Nepal",
                    EmailAddress = "devi123@gmail.com",
                    ContactNumber = "+9779841134576"
                });
            context.SaveChanges();

            context.Applications.AddOrUpdate(a => new { a.ApplicantID,a.CourseID},
                new Application()
                {
                    ApplicantID = context.Applicants.Where(a => a.SecondaryID == 1).Single().ApplicantID,
                    CourseID = context.Courses.Where(c => c.VetNationalCode == "BSB50215").Single().CourseID,
                    ProposedStartDate = DateTime.Parse("2019-01-28"),
                    ProposedEndDate = DateTime.Parse("2020-01-26"),
                    LooIssuedDate = DateTime.Parse("2018-12-25"),
                    LooExpiryDate = DateTime.Parse("2019-01-25"),
                    AirportPickup = false,
                    Accomodation = false,
                    Oshc = false,
                    AgentID = context.Agents.Where(a => a.LegalName == "Sealink Australia Pty Ltd").Single().AgentID,
                    ApplicationStatus = ApplicationStatus.Pending,
                    MarketingComment = "No Comment",
                    DepositReceived = true,
                    DepositReceivedDate = DateTime.Parse("2019-01-02"),
                    TuitionFeeReceived = 10000,
                    MaterialFeeReceived = 250,
                    ApplicationFeeReceived = 250,
                    OshcFeeReceived = 1201,
                    OutstandingAmount = 0,
                    FinanceComments = "No Comment",
                    ApplicationForm = true,
                    ApplicationFormReceivedDate = DateTime.Parse("2018-12-12"),
                    PreTrainingReview = true,
                    PtrCompletedDate = DateTime.Parse("2018-12-13"),
                    AcceptanceOfOffer = true,
                    AcceptanceOfOfferDate = DateTime.Parse("2019-01-02"),
                    AcademicTranscripts = true,
                    Passport = true,
                    IeltsOrEquivalent = true,
                    OshcCurrency = true,
                    FinancialViability = true,
                    CourseOutline = true,
                    GteReviewed = true,
                    AdministrationComment = "No Comment",
                    PreEnrolmentInformation = true,
                    EnrolledInSms = true,
                    eCoeIssued = true,
                    eCoeIssuedDate = DateTime.Parse("2019-01-12"),
                    DepositMatchingLoo = true,
                    DatesMatchingLoo = true,
                    CoeStatus = CoeStatus.Approved,
                    eCoeLastUpdated = DateTime.Parse("2019-01-12"),
                    RefundRequired = false,
                    RefundAmount = 0,
                    DateRefundProcessed = null,
                    CoeComment = "No Comment"


                },
                new Application()
                {
                    ApplicantID = context.Applicants.Where(a => a.SecondaryID == 2).Single().ApplicantID,
                    CourseID = context.Courses.Where(c => c.VetNationalCode == "BSB50215").Single().CourseID,
                    ProposedStartDate = DateTime.Parse("2019-01-28"),
                    ProposedEndDate = DateTime.Parse("2020-01-26"),
                    LooIssuedDate = DateTime.Parse("2018-12-25"),
                    LooExpiryDate = DateTime.Parse("2019-01-25"),
                    AirportPickup = false,
                    Accomodation = false,
                    Oshc = false,
                    AgentID = context.Agents.Where(a => a.LegalName == "Dolphine Consultancy Pty Ltd").Single().AgentID,
                    ApplicationStatus = ApplicationStatus.Pending,
                    MarketingComment = "No Comment",
                    DepositReceived = true,
                    DepositReceivedDate = DateTime.Parse("2018-12-28"),
                    TuitionFeeReceived = 10000,
                    MaterialFeeReceived = 250,
                    ApplicationFeeReceived = 250,
                    OshcFeeReceived = 1201,
                    OutstandingAmount = 0,
                    FinanceComments = "No Comment",
                    ApplicationForm = true,
                    ApplicationFormReceivedDate = DateTime.Parse("2018-12-01"),
                    PreTrainingReview = true,
                    PtrCompletedDate = DateTime.Parse("2018-12-01"),
                    AcceptanceOfOffer = true,
                    AcceptanceOfOfferDate = DateTime.Parse("2019-01-01"),
                    AcademicTranscripts = true,
                    Passport = true,
                    IeltsOrEquivalent = true,
                    OshcCurrency = true,
                    FinancialViability = true,
                    CourseOutline = true,
                    GteReviewed = true,
                    AdministrationComment = "No Comment",
                    PreEnrolmentInformation = true,
                    EnrolledInSms = true,
                    eCoeIssued = true,
                    eCoeIssuedDate = DateTime.Parse("2019-01-02"),
                    DepositMatchingLoo = true,
                    DatesMatchingLoo = true,
                    CoeStatus = CoeStatus.Approved,
                    eCoeLastUpdated = DateTime.Parse("2019-01-02"),
                    RefundRequired = false,
                    RefundAmount = 0,
                    DateRefundProcessed = null,
                    CoeComment = "No Comment"
                });
            context.SaveChanges();


        }
    }
}
