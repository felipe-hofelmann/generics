namespace WebAppEstamparia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Producoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Inicio = c.String(),
                        Fim = c.String(),
                        Operador = c.String(),
                        Auxiliar = c.String(),
                        Quantidade = c.Int(nullable: false),
                        PH = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Producaos");
        }
    }
}
