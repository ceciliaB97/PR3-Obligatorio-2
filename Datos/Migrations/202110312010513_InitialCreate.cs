namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actividades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cupos = c.Int(nullable: false),
                        EdadMinima = c.Int(nullable: false),
                        EdadMaxima = c.Int(nullable: false),
                        Nombre = c.String(),
                        Membresia_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Membresias", t => t.Membresia_Id)
                .Index(t => t.Membresia_Id);
            
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiaSemana = c.Int(nullable: false),
                        Hora = c.Int(nullable: false),
                        Actividad_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actividades", t => t.Actividad_Id)
                .Index(t => t.Actividad_Id);
            
            CreateTable(
                "dbo.Membresias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mes = c.Int(nullable: false),
                        Anio = c.Int(nullable: false),
                        FechaPago = c.DateTime(),
                        TipoMembresia = c.String(nullable: false, maxLength: 50),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                        CantActividades = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Socios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.Int(nullable: false),
                        NombreApellido = c.String(nullable: false, maxLength: 50),
                        FechaNacimiento = c.DateTime(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Cedula, unique: true);
            
            CreateTable(
                "dbo.ActividadesSocio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Actividad_Id = c.Int(nullable: false),
                        Socio_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actividades", t => t.Actividad_Id, cascadeDelete: true)
                .ForeignKey("dbo.Socios", t => t.Socio_Id, cascadeDelete: true)
                .Index(t => t.Actividad_Id)
                .Index(t => t.Socio_Id);
            
            CreateTable(
                "dbo.Configurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CantActividadesDescuento = c.Int(nullable: false),
                        DescuentoCuponera = c.Double(nullable: false),
                        CostoFijo = c.Double(nullable: false),
                        DescuentoPaseLibre = c.Double(nullable: false),
                        AntiguedadEstablecida = c.Int(nullable: false),
                        MontoUnitarioCuponera = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocioMembresias",
                c => new
                    {
                        Socio_Id = c.Int(nullable: false),
                        Membresia_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Socio_Id, t.Membresia_Id })
                .ForeignKey("dbo.Socios", t => t.Socio_Id, cascadeDelete: true)
                .ForeignKey("dbo.Membresias", t => t.Membresia_Id, cascadeDelete: true)
                .Index(t => t.Socio_Id)
                .Index(t => t.Membresia_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocioMembresias", "Membresia_Id", "dbo.Membresias");
            DropForeignKey("dbo.SocioMembresias", "Socio_Id", "dbo.Socios");
            DropForeignKey("dbo.ActividadesSocio", "Socio_Id", "dbo.Socios");
            DropForeignKey("dbo.ActividadesSocio", "Actividad_Id", "dbo.Actividades");
            DropForeignKey("dbo.Actividades", "Membresia_Id", "dbo.Membresias");
            DropForeignKey("dbo.Horarios", "Actividad_Id", "dbo.Actividades");
            DropIndex("dbo.SocioMembresias", new[] { "Membresia_Id" });
            DropIndex("dbo.SocioMembresias", new[] { "Socio_Id" });
            DropIndex("dbo.ActividadesSocio", new[] { "Socio_Id" });
            DropIndex("dbo.ActividadesSocio", new[] { "Actividad_Id" });
            DropIndex("dbo.Socios", new[] { "Cedula" });
            DropIndex("dbo.Horarios", new[] { "Actividad_Id" });
            DropIndex("dbo.Actividades", new[] { "Membresia_Id" });
            DropTable("dbo.SocioMembresias");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Configurations");
            DropTable("dbo.ActividadesSocio");
            DropTable("dbo.Socios");
            DropTable("dbo.Membresias");
            DropTable("dbo.Horarios");
            DropTable("dbo.Actividades");
        }
    }
}
