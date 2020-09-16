namespace SistemZaDonaciiNaKrv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allDonatorFormAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonatorFormModels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.DonatorFormModels", "ApplicationUser_Id");
            AddForeignKey("dbo.DonatorFormModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonatorFormModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.DonatorFormModels", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.DonatorFormModels", "ApplicationUser_Id");
        }
    }
}
