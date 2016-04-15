using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.infra.data.entityframework.identity;
using br.com.klinderrh.social.infra.data.entityframework.mapeamentos;
using Microsoft.AspNet.Identity.EntityFramework;

namespace br.com.klinderrh.social.infra.data.entityframework
{

	public class Contexto : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
	{

		public Contexto() : base("name=KinderRHSocialDB")
		{
			Database.SetInitializer<Contexto>(null); // Remove default initializer

			Configuration.LazyLoadingEnabled = false; // Para senários com dominios compexos.
			Configuration.ProxyCreationEnabled = false; // Para uma serialização mais suave.

			Database.Log = s => Debug.WriteLine(s);

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

			modelBuilder.Configurations.Add(new NivelDoCargoMap());
			modelBuilder.Configurations.Add(new CargoMap());
			modelBuilder.Configurations.Add(new CidadeMap());
			modelBuilder.Configurations.Add(new FuncionarioMap());
			modelBuilder.Configurations.Add(new ContatoMap());
			modelBuilder.Configurations.Add(new DepartamentoMap());
			modelBuilder.Configurations.Add(new EmpresaMap());
			modelBuilder.Configurations.Add(new UnidadeMap());
			modelBuilder.Configurations.Add(new EnderecoMap());
			modelBuilder.Configurations.Add(new TipoDeEnderecoMap());
			modelBuilder.Configurations.Add(new PaisMap());
			modelBuilder.Configurations.Add(new EstadoMap());
			modelBuilder.Configurations.Add(new PessoaMap());
			modelBuilder.Configurations.Add(new UsuarioMap());

			// Asp.Net Identity
			modelBuilder.Entity<ApplicationRole>().HasKey(r => r.Id);
			modelBuilder.Entity<ApplicationUserClaim>().HasKey(uc => uc.Id);
			modelBuilder.Entity<ApplicationUserRole>().HasKey(ur => new { ur.RoleId, ur.UserId });
			modelBuilder.Entity<ApplicationUserLogin>().HasKey(ul => new { ul.UserId, ul.LoginProvider, ul.ProviderKey });

		}

		#region DbSet Collections

		public IDbSet<Cargo> Cargos { get; set; }
		public IDbSet<Cidade> Cidades { get; set; }
		public IDbSet<Funcionario> Colaboradores { get; set; }
		public IDbSet<Contato> Contatos { get; set; }
		public IDbSet<Departamento> Departamentos { get; set; }
		public IDbSet<Empresa> Empresas { get; set; }
		public IDbSet<Unidade> Unidades { get; set; }
		public IDbSet<Endereco> Enderecos { get; set; }
		public IDbSet<Pais> Paises { get; set; }
		public IDbSet<Estado> Estados { get; set; }
		public IDbSet<Pessoa> Pessoas { get; set; }
		public IDbSet<Usuario> Usuarios { get; set; }

		#endregion

	}

}