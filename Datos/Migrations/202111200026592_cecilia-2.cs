namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cecilia2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actividades", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actividades", "Active");
        }
    }
}
