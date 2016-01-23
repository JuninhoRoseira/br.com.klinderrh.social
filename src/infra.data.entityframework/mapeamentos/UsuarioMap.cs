using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
{
	public class UsuarioMap : MapeamentoBase<Usuario>
	{
		public UsuarioMap()
		{
			ToTable("Usuario");

			Property(u => u.Senha).HasMaxLength(100).IsRequired();
			Property(u => u.Nome).HasMaxLength(50).IsRequired().HasColumnAnnotation("Index", NovoIndice("IX_Usuario_Nome"));
			Property(u => u.Email).HasMaxLength(50).IsRequired();

		}

	}

	public class CargoMap : MapeamentoBase<Cargo>
	{
		public CargoMap()
		{
			ToTable("Cargo");

			Property(c => c.Nome).HasMaxLength(50).IsRequired().HasColumnAnnotation("Index", NovoIndice("IX_Cargo_Nome"));
			Property(c => c.Sigla).HasMaxLength(10).IsOptional();
			Property(c => c.Descricao).HasMaxLength(500).IsOptional();

		}

	}

}