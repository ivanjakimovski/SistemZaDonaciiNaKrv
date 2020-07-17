namespace SistemZaDonaciiNaKrv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonatorFormModels", "daliOdobreno", c => c.Boolean(nullable: false));
            AddColumn("dbo.DonatorFormModels", "daliZolticaMalarija", c => c.Boolean(nullable: false));
            AddColumn("dbo.DonatorFormModels", "daliSrceviPritisok", c => c.Boolean(nullable: false));
            AddColumn("dbo.DonatorFormModels", "daliAlergjaAstma", c => c.Boolean(nullable: false));
            AddColumn("dbo.DonatorFormModels", "daliGrcevi", c => c.Boolean(nullable: false));
            AddColumn("dbo.DonatorFormModels", "daliHronicni", c => c.Boolean(nullable: false));
            AddColumn("dbo.DonatorFormModels", "daliToksoPlazmoza", c => c.Boolean(nullable: false));
            AddColumn("dbo.DonatorFormModels", "daliBruceloza", c => c.Boolean(nullable: false));
            DropColumn("dbo.DonatorFormModels", "Bolest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DonatorFormModels", "Bolest", c => c.String());
            DropColumn("dbo.DonatorFormModels", "daliBruceloza");
            DropColumn("dbo.DonatorFormModels", "daliToksoPlazmoza");
            DropColumn("dbo.DonatorFormModels", "daliHronicni");
            DropColumn("dbo.DonatorFormModels", "daliGrcevi");
            DropColumn("dbo.DonatorFormModels", "daliAlergjaAstma");
            DropColumn("dbo.DonatorFormModels", "daliSrceviPritisok");
            DropColumn("dbo.DonatorFormModels", "daliZolticaMalarija");
            DropColumn("dbo.DonatorFormModels", "daliOdobreno");
        }
    }
}
