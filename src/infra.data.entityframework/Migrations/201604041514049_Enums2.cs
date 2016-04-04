namespace br.com.klinderrh.social.infra.data.entityframework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enums2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargo",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Sigla = c.String(maxLength: 10, unicode: false),
                        Descricao = c.String(maxLength: 1000, unicode: false),
                        CodigoDoNivelDoCargo = c.Int(nullable: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .Index(t => t.Nome, name: "IX_Cargo_Nome");
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Sigla = c.String(maxLength: 10, unicode: false),
                        CodigoDoEstado = c.Int(nullable: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Estado", t => t.CodigoDoEstado)
                .Index(t => t.Nome, name: "IX_Cidade_Nome")
                .Index(t => t.CodigoDoEstado);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        UnidadeFederativa = c.String(nullable: false, maxLength: 2, unicode: false),
                        CodigoDoPais = c.Int(nullable: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Pais", t => t.CodigoDoPais)
                .Index(t => t.Nome, name: "IX_Estado_Nome")
                .Index(t => t.CodigoDoPais);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .Index(t => t.Nome, name: "IX_Pais_Nome");
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Matricula = c.String(nullable: false, maxLength: 50, unicode: false),
                        CodigoDaPessoa = c.Int(nullable: false),
                        CodigoDaEmpresa = c.Int(nullable: false),
                        CodigoDoDepartamento = c.Int(nullable: false),
                        CodigoDoCargo = c.Int(nullable: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Cargo", t => t.CodigoDoCargo)
                .ForeignKey("dbo.Departamento", t => t.CodigoDoDepartamento)
                .ForeignKey("dbo.Empresa", t => t.CodigoDaEmpresa)
                .ForeignKey("dbo.Pessoa", t => t.CodigoDaPessoa)
                .Index(t => t.Matricula, unique: true, name: "IX_Funcionario_Matricula")
                .Index(t => t.CodigoDaPessoa)
                .Index(t => t.CodigoDaEmpresa)
                .Index(t => t.CodigoDoDepartamento)
                .Index(t => t.CodigoDoCargo);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Sigla = c.String(maxLength: 10, unicode: false),
                        Descricao = c.String(maxLength: 500, unicode: false),
                        CodigoDoDepartamentoPai = c.Int(),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Departamento", t => t.CodigoDoDepartamentoPai)
                .Index(t => t.CodigoDoDepartamentoPai);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        RazaoSocial = c.String(nullable: false, maxLength: 100, unicode: false),
                        NomeFantasia = c.String(maxLength: 50, unicode: false),
                        CNPJ = c.String(nullable: false, maxLength: 8000, unicode: false),
                        IE = c.String(nullable: false, maxLength: 8000, unicode: false),
                        DataDeAdesao = c.DateTime(nullable: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .Index(t => t.RazaoSocial, name: "IX_Empresa_RazaoSocial")
                .Index(t => t.NomeFantasia, name: "IX_Empresa_NomeFantasia")
                .Index(t => t.CNPJ, unique: true, name: "IX_Empresa_CNPJ");
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        RG = c.String(nullable: false, maxLength: 20, unicode: false),
                        CPF = c.String(nullable: false, maxLength: 20, unicode: false),
                        DataDeNascimento = c.DateTime(nullable: false),
                        CodigoDoUsuario = c.Int(),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Usuario", t => t.CodigoDoUsuario)
                .Index(t => t.Nome, name: "IX_Pessoa_Nome")
                .Index(t => t.CodigoDoUsuario);
            
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Telefone = c.String(maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        CodigoDoTipoDeEndereco = c.Int(nullable: false),
                        Logradouro = c.String(maxLength: 50, unicode: false),
                        Numero = c.String(maxLength: 50, unicode: false),
                        Complemento = c.String(maxLength: 50, unicode: false),
                        CEP = c.String(nullable: false, maxLength: 8, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 50, unicode: false),
                        CodigoDaCidade = c.Int(nullable: false),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Cidade", t => t.CodigoDaCidade)
                .Index(t => t.CodigoDaCidade);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 100, unicode: false),
                        Valido = c.Boolean(),
                        DataDeCadastro = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .Index(t => t.Nome, unique: true, name: "IX_Usuario_Nome")
                .Index(t => t.Email, unique: true, name: "IX_Usuario_Email");
            
            CreateTable(
                "dbo.NivelDoCargoEnum",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.TipoDeEnderecoEnum",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.PessoasXContatos",
                c => new
                    {
                        CodigoDaPessoa = c.Int(nullable: false),
                        CodigoDoContato = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CodigoDaPessoa, t.CodigoDoContato })
                .ForeignKey("dbo.Pessoa", t => t.CodigoDaPessoa)
                .ForeignKey("dbo.Contato", t => t.CodigoDoContato)
                .Index(t => t.CodigoDaPessoa)
                .Index(t => t.CodigoDoContato);
            
            CreateTable(
                "dbo.PessoasXEnderecos",
                c => new
                    {
                        CodigoDaPessoa = c.Int(nullable: false),
                        CodigoDoEndereco = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CodigoDaPessoa, t.CodigoDoEndereco })
                .ForeignKey("dbo.Pessoa", t => t.CodigoDaPessoa)
                .ForeignKey("dbo.Endereco", t => t.CodigoDoEndereco)
                .Index(t => t.CodigoDaPessoa)
                .Index(t => t.CodigoDoEndereco);
            
            CreateTable(
                "dbo.EmpresasXContatos",
                c => new
                    {
                        CodigoDaEmpresa = c.Int(nullable: false),
                        CodigoDoContato = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CodigoDaEmpresa, t.CodigoDoContato })
                .ForeignKey("dbo.Empresa", t => t.CodigoDaEmpresa)
                .ForeignKey("dbo.Pessoa", t => t.CodigoDoContato)
                .Index(t => t.CodigoDaEmpresa)
                .Index(t => t.CodigoDoContato);
            
            CreateTable(
                "dbo.EmpresasXEnderecos",
                c => new
                    {
                        CodigoDaEmpresa = c.Int(nullable: false),
                        CodigoDoEndereco = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CodigoDaEmpresa, t.CodigoDoEndereco })
                .ForeignKey("dbo.Empresa", t => t.CodigoDaEmpresa)
                .ForeignKey("dbo.Endereco", t => t.CodigoDoEndereco)
                .Index(t => t.CodigoDaEmpresa)
                .Index(t => t.CodigoDoEndereco);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionario", "CodigoDaPessoa", "dbo.Pessoa");
            DropForeignKey("dbo.Funcionario", "CodigoDaEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.EmpresasXEnderecos", "CodigoDoEndereco", "dbo.Endereco");
            DropForeignKey("dbo.EmpresasXEnderecos", "CodigoDaEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.EmpresasXContatos", "CodigoDoContato", "dbo.Pessoa");
            DropForeignKey("dbo.EmpresasXContatos", "CodigoDaEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.Pessoa", "CodigoDoUsuario", "dbo.Usuario");
            DropForeignKey("dbo.PessoasXEnderecos", "CodigoDoEndereco", "dbo.Endereco");
            DropForeignKey("dbo.PessoasXEnderecos", "CodigoDaPessoa", "dbo.Pessoa");
            DropForeignKey("dbo.Endereco", "CodigoDaCidade", "dbo.Cidade");
            DropForeignKey("dbo.PessoasXContatos", "CodigoDoContato", "dbo.Contato");
            DropForeignKey("dbo.PessoasXContatos", "CodigoDaPessoa", "dbo.Pessoa");
            DropForeignKey("dbo.Funcionario", "CodigoDoDepartamento", "dbo.Departamento");
            DropForeignKey("dbo.Departamento", "CodigoDoDepartamentoPai", "dbo.Departamento");
            DropForeignKey("dbo.Funcionario", "CodigoDoCargo", "dbo.Cargo");
            DropForeignKey("dbo.Cidade", "CodigoDoEstado", "dbo.Estado");
            DropForeignKey("dbo.Estado", "CodigoDoPais", "dbo.Pais");
            DropIndex("dbo.EmpresasXEnderecos", new[] { "CodigoDoEndereco" });
            DropIndex("dbo.EmpresasXEnderecos", new[] { "CodigoDaEmpresa" });
            DropIndex("dbo.EmpresasXContatos", new[] { "CodigoDoContato" });
            DropIndex("dbo.EmpresasXContatos", new[] { "CodigoDaEmpresa" });
            DropIndex("dbo.PessoasXEnderecos", new[] { "CodigoDoEndereco" });
            DropIndex("dbo.PessoasXEnderecos", new[] { "CodigoDaPessoa" });
            DropIndex("dbo.PessoasXContatos", new[] { "CodigoDoContato" });
            DropIndex("dbo.PessoasXContatos", new[] { "CodigoDaPessoa" });
            DropIndex("dbo.Usuario", "IX_Usuario_Email");
            DropIndex("dbo.Usuario", "IX_Usuario_Nome");
            DropIndex("dbo.Endereco", new[] { "CodigoDaCidade" });
            DropIndex("dbo.Pessoa", new[] { "CodigoDoUsuario" });
            DropIndex("dbo.Pessoa", "IX_Pessoa_Nome");
            DropIndex("dbo.Empresa", "IX_Empresa_CNPJ");
            DropIndex("dbo.Empresa", "IX_Empresa_NomeFantasia");
            DropIndex("dbo.Empresa", "IX_Empresa_RazaoSocial");
            DropIndex("dbo.Departamento", new[] { "CodigoDoDepartamentoPai" });
            DropIndex("dbo.Funcionario", new[] { "CodigoDoCargo" });
            DropIndex("dbo.Funcionario", new[] { "CodigoDoDepartamento" });
            DropIndex("dbo.Funcionario", new[] { "CodigoDaEmpresa" });
            DropIndex("dbo.Funcionario", new[] { "CodigoDaPessoa" });
            DropIndex("dbo.Funcionario", "IX_Funcionario_Matricula");
            DropIndex("dbo.Pais", "IX_Pais_Nome");
            DropIndex("dbo.Estado", new[] { "CodigoDoPais" });
            DropIndex("dbo.Estado", "IX_Estado_Nome");
            DropIndex("dbo.Cidade", new[] { "CodigoDoEstado" });
            DropIndex("dbo.Cidade", "IX_Cidade_Nome");
            DropIndex("dbo.Cargo", "IX_Cargo_Nome");
            DropTable("dbo.EmpresasXEnderecos");
            DropTable("dbo.EmpresasXContatos");
            DropTable("dbo.PessoasXEnderecos");
            DropTable("dbo.PessoasXContatos");
            DropTable("dbo.TipoDeEnderecoEnum");
            DropTable("dbo.NivelDoCargoEnum");
            DropTable("dbo.Usuario");
            DropTable("dbo.Endereco");
            DropTable("dbo.Contato");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Empresa");
            DropTable("dbo.Departamento");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Pais");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
            DropTable("dbo.Cargo");
        }
    }
}
