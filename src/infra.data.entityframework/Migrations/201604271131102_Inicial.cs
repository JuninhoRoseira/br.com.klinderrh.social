namespace KlinderRH.Social.Infra.Data.EntityFramework.Migrations
{
	using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargo",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Sigla = c.String(maxLength: 10, unicode: false),
                        Descricao = c.String(maxLength: 1000, unicode: false),
                        NivelDoCargoId = c.Int(nullable: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome, name: "IX_Cargo_Nome");
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Sigla = c.String(maxLength: 10, unicode: false),
                        EstadoId = c.Guid(nullable: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .Index(t => t.Nome, name: "IX_Cidade_Nome")
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        UnidadeFederativa = c.String(nullable: false, maxLength: 2, unicode: false),
                        PaisId = c.Guid(nullable: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pais", t => t.PaisId)
                .Index(t => t.Nome, name: "IX_Estado_Nome")
                .Index(t => t.PaisId);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome, name: "IX_Pais_Nome");
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Matricula = c.String(nullable: false, maxLength: 50, unicode: false),
                        PessoaId = c.Guid(nullable: false),
                        UnidadeId = c.Guid(nullable: false),
                        DepartamentoId = c.Guid(nullable: false),
                        CargoId = c.Guid(nullable: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cargo", t => t.CargoId)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .ForeignKey("dbo.Unidade", t => t.UnidadeId)
                .Index(t => t.Matricula, unique: true, name: "IX_Funcionario_Matricula")
                .Index(t => t.PessoaId)
                .Index(t => t.UnidadeId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.CargoId);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Sigla = c.String(maxLength: 10, unicode: false),
                        Descricao = c.String(maxLength: 500, unicode: false),
                        DepartamentoPaiId = c.Guid(),
                        UnidadeId = c.Guid(nullable: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoPaiId)
                .ForeignKey("dbo.Unidade", t => t.UnidadeId)
                .Index(t => t.DepartamentoPaiId)
                .Index(t => t.UnidadeId);
            
            CreateTable(
                "dbo.Unidade",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RazaoSocial = c.String(nullable: false, maxLength: 100, unicode: false),
                        NomeFantasia = c.String(maxLength: 50, unicode: false),
                        CNPJ = c.String(nullable: false, maxLength: 8000, unicode: false),
                        IE = c.String(nullable: false, maxLength: 8000, unicode: false),
                        EmpresaId = c.Guid(nullable: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .Index(t => t.RazaoSocial, name: "IX_Empresa_RazaoSocial")
                .Index(t => t.NomeFantasia, name: "IX_Empresa_NomeFantasia")
                .Index(t => t.CNPJ, unique: true, name: "IX_Empresa_CNPJ")
                .Index(t => t.EmpresaId);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RazaoSocial = c.String(nullable: false, maxLength: 100, unicode: false),
                        NomeFantasia = c.String(maxLength: 50, unicode: false),
                        CNPJ = c.String(nullable: false, maxLength: 20, unicode: false),
                        IE = c.String(nullable: false, maxLength: 20, unicode: false),
                        DataDeAdesao = c.DateTime(nullable: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RazaoSocial, name: "IX_Empresa_RazaoSocial")
                .Index(t => t.NomeFantasia, name: "IX_Empresa_NomeFantasia")
                .Index(t => t.CNPJ, unique: true, name: "IX_Empresa_CNPJ");
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        RG = c.String(nullable: false, maxLength: 20, unicode: false),
                        CPF = c.String(nullable: false, maxLength: 20, unicode: false),
                        DataDeNascimento = c.DateTime(nullable: false),
                        UsuarioId = c.Guid(),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.Nome, name: "IX_Pessoa_Nome")
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Telefone = c.String(maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        TipoDeEnderecoId = c.Int(nullable: false),
                        Logradouro = c.String(maxLength: 50, unicode: false),
                        Numero = c.String(maxLength: 50, unicode: false),
                        Complemento = c.String(maxLength: 50, unicode: false),
                        CEP = c.String(nullable: false, maxLength: 8, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 50, unicode: false),
                        CidadeId = c.Guid(nullable: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cidade", t => t.CidadeId)
                .Index(t => t.CidadeId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        EmailConfirmado = c.Boolean(nullable: false),
                        Senha = c.String(nullable: false, maxLength: 100, unicode: false),
                        Valido = c.Boolean(),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome, unique: true, name: "IX_Usuario_Nome")
                .Index(t => t.Email, unique: true, name: "IX_Usuario_Email");
            
            CreateTable(
                "dbo.ApplicationRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserRole",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        ApplicationRole_Id = c.Guid(),
                        ApplicationUser_Id = c.Guid(),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.ApplicationRole", t => t.ApplicationRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 8000, unicode: false),
                        Email = c.String(maxLength: 8000, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 8000, unicode: false),
                        SecurityStamp = c.String(maxLength: 8000, unicode: false),
                        PhoneNumber = c.String(maxLength: 8000, unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(maxLength: 8000, unicode: false),
                        ClaimValue = c.String(maxLength: 8000, unicode: false),
                        ApplicationUser_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUserLogin",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        LoginProvider = c.String(nullable: false, maxLength: 128, unicode: false),
                        ProviderKey = c.String(nullable: false, maxLength: 128, unicode: false),
                        ApplicationUser_Id = c.Guid(),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.NivelDoCargoEnum",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoDeEnderecoEnum",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PessoasXContatos",
                c => new
                    {
                        PessoaId = c.Guid(nullable: false),
                        ContatoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PessoaId, t.ContatoId })
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .ForeignKey("dbo.Contato", t => t.ContatoId)
                .Index(t => t.PessoaId)
                .Index(t => t.ContatoId);
            
            CreateTable(
                "dbo.PessoasXEnderecos",
                c => new
                    {
                        PessoaId = c.Guid(nullable: false),
                        EnderecoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PessoaId, t.EnderecoId })
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId)
                .Index(t => t.PessoaId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.EmpresasXContatos",
                c => new
                    {
                        EmpresaId = c.Guid(nullable: false),
                        ContatoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmpresaId, t.ContatoId })
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .ForeignKey("dbo.Pessoa", t => t.ContatoId)
                .Index(t => t.EmpresaId)
                .Index(t => t.ContatoId);
            
            CreateTable(
                "dbo.EmpresasXEnderecos",
                c => new
                    {
                        EmpresaId = c.Guid(nullable: false),
                        EnderecoId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmpresaId, t.EnderecoId })
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId)
                .Index(t => t.EmpresaId)
                .Index(t => t.EnderecoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUserRole", "ApplicationRole_Id", "dbo.ApplicationRole");
            DropForeignKey("dbo.Funcionario", "UnidadeId", "dbo.Unidade");
            DropForeignKey("dbo.Funcionario", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Funcionario", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.Unidade", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.EmpresasXEnderecos", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.EmpresasXEnderecos", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.EmpresasXContatos", "ContatoId", "dbo.Pessoa");
            DropForeignKey("dbo.EmpresasXContatos", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.Pessoa", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.PessoasXEnderecos", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.PessoasXEnderecos", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Endereco", "CidadeId", "dbo.Cidade");
            DropForeignKey("dbo.PessoasXContatos", "ContatoId", "dbo.Contato");
            DropForeignKey("dbo.PessoasXContatos", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Departamento", "UnidadeId", "dbo.Unidade");
            DropForeignKey("dbo.Departamento", "DepartamentoPaiId", "dbo.Departamento");
            DropForeignKey("dbo.Funcionario", "CargoId", "dbo.Cargo");
            DropForeignKey("dbo.Cidade", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Estado", "PaisId", "dbo.Pais");
            DropIndex("dbo.EmpresasXEnderecos", new[] { "EnderecoId" });
            DropIndex("dbo.EmpresasXEnderecos", new[] { "EmpresaId" });
            DropIndex("dbo.EmpresasXContatos", new[] { "ContatoId" });
            DropIndex("dbo.EmpresasXContatos", new[] { "EmpresaId" });
            DropIndex("dbo.PessoasXEnderecos", new[] { "EnderecoId" });
            DropIndex("dbo.PessoasXEnderecos", new[] { "PessoaId" });
            DropIndex("dbo.PessoasXContatos", new[] { "ContatoId" });
            DropIndex("dbo.PessoasXContatos", new[] { "PessoaId" });
            DropIndex("dbo.ApplicationUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserRole", new[] { "ApplicationRole_Id" });
            DropIndex("dbo.Usuario", "IX_Usuario_Email");
            DropIndex("dbo.Usuario", "IX_Usuario_Nome");
            DropIndex("dbo.Endereco", new[] { "CidadeId" });
            DropIndex("dbo.Pessoa", new[] { "UsuarioId" });
            DropIndex("dbo.Pessoa", "IX_Pessoa_Nome");
            DropIndex("dbo.Empresa", "IX_Empresa_CNPJ");
            DropIndex("dbo.Empresa", "IX_Empresa_NomeFantasia");
            DropIndex("dbo.Empresa", "IX_Empresa_RazaoSocial");
            DropIndex("dbo.Unidade", new[] { "EmpresaId" });
            DropIndex("dbo.Unidade", "IX_Empresa_CNPJ");
            DropIndex("dbo.Unidade", "IX_Empresa_NomeFantasia");
            DropIndex("dbo.Unidade", "IX_Empresa_RazaoSocial");
            DropIndex("dbo.Departamento", new[] { "UnidadeId" });
            DropIndex("dbo.Departamento", new[] { "DepartamentoPaiId" });
            DropIndex("dbo.Funcionario", new[] { "CargoId" });
            DropIndex("dbo.Funcionario", new[] { "DepartamentoId" });
            DropIndex("dbo.Funcionario", new[] { "UnidadeId" });
            DropIndex("dbo.Funcionario", new[] { "PessoaId" });
            DropIndex("dbo.Funcionario", "IX_Funcionario_Matricula");
            DropIndex("dbo.Pais", "IX_Pais_Nome");
            DropIndex("dbo.Estado", new[] { "PaisId" });
            DropIndex("dbo.Estado", "IX_Estado_Nome");
            DropIndex("dbo.Cidade", new[] { "EstadoId" });
            DropIndex("dbo.Cidade", "IX_Cidade_Nome");
            DropIndex("dbo.Cargo", "IX_Cargo_Nome");
            DropTable("dbo.EmpresasXEnderecos");
            DropTable("dbo.EmpresasXContatos");
            DropTable("dbo.PessoasXEnderecos");
            DropTable("dbo.PessoasXContatos");
            DropTable("dbo.TipoDeEnderecoEnum");
            DropTable("dbo.NivelDoCargoEnum");
            DropTable("dbo.ApplicationUserLogin");
            DropTable("dbo.ApplicationUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.ApplicationUserRole");
            DropTable("dbo.ApplicationRole");
            DropTable("dbo.Usuario");
            DropTable("dbo.Endereco");
            DropTable("dbo.Contato");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Empresa");
            DropTable("dbo.Unidade");
            DropTable("dbo.Departamento");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Pais");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
            DropTable("dbo.Cargo");
        }
    }
}
