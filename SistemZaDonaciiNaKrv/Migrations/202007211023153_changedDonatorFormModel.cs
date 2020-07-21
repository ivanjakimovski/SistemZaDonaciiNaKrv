namespace SistemZaDonaciiNaKrv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDonatorFormModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonatorFormModels", "DonorId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonatorFormModels", "DonorId", c => c.Int(nullable: false));
        }
    }
}
