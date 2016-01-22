namespace br.com.klinderrh.social.infra.data.entityframework.Migrations
{
	using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .Index(t => t.Nome, name: "IX_Usuario_Nome");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuario", "IX_Usuario_Nome");
            DropTable("dbo.Usuario");
        }
    }
}
