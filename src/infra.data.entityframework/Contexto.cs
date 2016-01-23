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
			modelBuilder.Configurations.Add(new UsuarioMap());
			modelBuilder.Configurations.Add(new CargoMap());

			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Properties<string>()
				.Configure(p => p.HasColumnType("varchar"));

		}

		public IDbSet<Usuario> Usuarios { get; set; }
		public IDbSet<Cargo> Cargos { get; set; }

	}

}