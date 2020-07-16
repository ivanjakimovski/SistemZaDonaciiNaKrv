namespace SistemZaDonaciiNaKrv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFormModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonatorFormModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonorId = c.Int(nullable: false),
                        Name = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        daliDenesSeCuvstvuvateZdravi = c.Boolean(nullable: false),
                        daliDenesNastinkaGrip = c.Boolean(nullable: false),
                        daliLekuvaleZabi = c.Boolean(nullable: false),
                        daliVakcina = c.Boolean(nullable: false),
                        daliOperacija = c.Boolean(nullable: false),
                        daliOperacijaSeriozniMedIspituvanja = c.Boolean(nullable: false),
                        daliTetovaza = c.Boolean(nullable: false),
                        daliUbod = c.Boolean(nullable: false),
                        daliTransfuzija = c.Boolean(nullable: false),
                        daliBesnilo = c.Boolean(nullable: false),
                        daliZoltica = c.Boolean(nullable: false),
                        daliBremeni = c.Boolean(nullable: false),
                        daliLekovi = c.Boolean(nullable: false),
                        daliHipofiza = c.Boolean(nullable: false),
                        daliMozocnaObvivka = c.Boolean(nullable: false),
                        daliRoznica = c.Boolean(nullable: false),
                        Bolest = c.String(),
                        daliHiv = c.Boolean(nullable: false),
                        daliDroga = c.Boolean(nullable: false),
                        daliPariIliDrogaZaSex = c.Boolean(nullable: false),
                        daliHemofilijaSex = c.Boolean(nullable: false),
                        daliOdnosSoDrugMazi = c.Boolean(nullable: false),
                        daliSexSoMazKojImalSexSoDrugMaz = c.Boolean(nullable: false),
                        daliSexSoHivPozitivenIliZoltica = c.Boolean(nullable: false),
                        daliSexSoPrimatelNaDroga = c.Boolean(nullable: false),
                        daliSexSoPrimatelNaPariIliDrogaZaSex = c.Boolean(nullable: false),
                        daliCreutzfeldtJokob = c.Boolean(nullable: false),
                        daliPolovoPrenoslivaBolest = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DonatorFormModels");
        }
    }
}
