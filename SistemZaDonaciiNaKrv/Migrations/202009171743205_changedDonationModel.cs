namespace SistemZaDonaciiNaKrv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDonationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonationModels", "Name", c => c.String());
            AddColumn("dbo.DonationModels", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonationModels", "LastName");
            DropColumn("dbo.DonationModels", "Name");
        }
    }
}
