namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class corrida1cecilia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Membresias", "Nombre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Membresias", "Nombre");
        }
    }
}
