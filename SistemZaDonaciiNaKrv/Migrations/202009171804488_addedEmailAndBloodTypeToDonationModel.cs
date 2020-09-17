namespace SistemZaDonaciiNaKrv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEmailAndBloodTypeToDonationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonationModels", "bloodType", c => c.String());
            AddColumn("dbo.DonationModels", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonationModels", "Email");
            DropColumn("dbo.DonationModels", "bloodType");
        }
    }
}
