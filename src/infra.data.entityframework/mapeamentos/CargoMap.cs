using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
{
	public class CargoMap : MapeamentoBase<Cargo>
	{
		public CargoMap()
		{
			ToTable("Cargo");

			Property(c => c.Nome).HasMaxLength(100).IsRequired().HasColumnAnnotation("Index", NovoIndice("IX_Cargo_Nome"));
			Property(c => c.Sigla).HasMaxLength(10).IsOptional();
			Property(c => c.Descricao).HasMaxLength(1000).IsOptional();

		}

	}

}