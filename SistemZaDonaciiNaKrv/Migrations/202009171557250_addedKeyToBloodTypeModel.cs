namespace SistemZaDonaciiNaKrv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedKeyToBloodTypeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodTypeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        APositive = c.Long(nullable: false),
                        ANegative = c.Long(nullable: false),
                        BPositive = c.Long(nullable: false),
                        BNegative = c.Long(nullable: false),
                        ABPositive = c.Long(nullable: false),
                        ABNegative = c.Long(nullable: false),
                        OPositive = c.Long(nullable: false),
                        ONegative = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BloodTypeModels");
        }
    }
}
