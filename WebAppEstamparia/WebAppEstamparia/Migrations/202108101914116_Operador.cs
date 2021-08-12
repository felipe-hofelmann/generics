namespace WebAppEstamparia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Operador : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Operadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataNasc = c.DateTime(nullable: false),
                        DataAdmicao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Producaos", "Operador_Id", c => c.Int());
            CreateIndex("dbo.Producaos", "Operador_Id");
            AddForeignKey("dbo.Producaos", "Operador_Id", "dbo.Operadors", "Id");
            DropColumn("dbo.Producaos", "Operador");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Producaos", "Operador", c => c.String());
            DropForeignKey("dbo.Producaos", "Operador_Id", "dbo.Operadors");
            DropIndex("dbo.Producaos", new[] { "Operador_Id" });
            DropColumn("dbo.Producaos", "Operador_Id");
            DropTable("dbo.Operadors");
        }
    }
}
