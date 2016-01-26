using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.infra.data.entityframework.mapeamentos;

namespace br.com.klinderrh.social.infra.data.entityframework
{
	public class Contexto : DbContext
	{
		//private static Contexto _contexto;

		//public static Contexto Instancia => _contexto ?? (_contexto = new Contexto());

		public Contexto()
			: base("name=KinderRHSocialDB")
		{
			// Database.SetInitializer<DevStoreDataContext>(new DevStoreDataContextInitializer());

			Configuration.LazyLoadingEnabled = false; // Para senários com dominios compexos.
			Configuration.ProxyCreationEnabled = false; // Para uma serialização mais suave.

			Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new CargoMap());
			modelBuilder.Configurations.Add(new CidadeMap());
			modelBuilder.Configurations.Add(new FuncionarioMap());
			modelBuilder.Configurations.Add(new ContatoMap());
			modelBuilder.Configurations.Add(new DepartamentoMap());
			modelBuilder.Configurations.Add(new EmpresaMap());
			modelBuilder.Configurations.Add(new EnderecoMap());
			modelBuilder.Configurations.Add(new EstadoMap());
			modelBuilder.Configurations.Add(new PessoaMap());
			modelBuilder.Configurations.Add(new UsuarioMap());

			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Properties<string>()
				.Configure(p => p.HasColumnType("varchar"));

		}

		public IDbSet<Cargo> Cargos { get; set; }
		public IDbSet<Cidade> Cidades { get; set; }
		public IDbSet<Funcionario> Colaboradores { get; set; }
		public IDbSet<Contato> Contatos { get; set; }
		public IDbSet<Departamento> Departamentos { get; set; }
		public IDbSet<Empresa> Empresas { get; set; }
		public IDbSet<Endereco> Enderecos { get; set; }
		public IDbSet<Estado> Estados { get; set; }
		public IDbSet<Pessoa> Pessoas { get; set; }
		public IDbSet<Usuario> Usuarios { get; set; }

	}

}