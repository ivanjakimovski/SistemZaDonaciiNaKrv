namespace SistemZaDonaciiNaKrv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDonationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonationModels", "isDone", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonationModels", "isDone");
        }
    }
}
