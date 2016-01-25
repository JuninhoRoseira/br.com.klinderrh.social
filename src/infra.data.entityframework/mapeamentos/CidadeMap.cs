using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
{
	public class CidadeMap : MapeamentoBase<Cidade>
	{
		public CidadeMap()
		{
			ToTable("Cidade");

			Property(e => e.Nome).HasMaxLength(50).IsRequired().HasColumnAnnotation("Index", NovoIndice("IX_Cidade_Nome"));
			Property(e => e.Sigla).HasMaxLength(10).IsOptional();

			HasRequired(c => c.Estado)
				.WithRequiredPrincipal()
				.Map(e => e.MapKey("CodigoEstado"));

		}

	}
}