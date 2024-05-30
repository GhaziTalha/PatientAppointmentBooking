namespace PatientAppointmentBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientBookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        MobileNo = c.String(nullable: false),
                        EmailID = c.String(nullable: false),
                        DoctorName = c.String(nullable: false),
                        AppointmentSlot = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PatientBookings");
        }
    }
}
