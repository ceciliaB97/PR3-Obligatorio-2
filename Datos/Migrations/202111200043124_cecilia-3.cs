namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cecilia3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actividades", "Nombre", c => c.String(maxLength: 30));
            CreateIndex("dbo.Actividades", "Nombre", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Actividades", new[] { "Nombre" });
            AlterColumn("dbo.Actividades", "Nombre", c => c.String());
        }
    }
}
