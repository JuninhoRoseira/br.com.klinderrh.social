using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
{
	public class CidadeMap : MapeamentoBase<Cidade>
	{
		public CidadeMap()
		{
			ToTable("Cidade");

			Property(c => c.Nome).HasMaxLength(100).IsRequired().HasColumnAnnotation("Index", NovoIndice("IX_Cidade_Nome"));
			Property(c => c.Sigla).HasMaxLength(10).IsOptional();

			HasRequired(c => c.Estado)
				.WithMany(e => e.Cidades)
				.HasForeignKey(c => c.CodigoDoEstado);

		}

	}

}