namespace SistemZaDonaciiNaKrv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "bloodType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "bloodType");
        }
    }
}
