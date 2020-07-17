namespace SistemZaDonaciiNaKrv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonationTime = c.DateTime(nullable: false),
                        City = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "hasDonated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonationModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.DonationModels", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "hasDonated");
            DropColumn("dbo.AspNetUsers", "City");
            DropTable("dbo.DonationModels");
        }
    }
}
