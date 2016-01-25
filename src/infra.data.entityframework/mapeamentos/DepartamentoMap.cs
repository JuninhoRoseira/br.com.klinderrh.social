using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
{
	public class DepartamentoMap : MapeamentoBase<Departamento>
	{
		public DepartamentoMap()
		{
			ToTable("Departamento");

			Property(d => d.Nome).HasMaxLength(50).IsRequired();
			Property(d => d.Sigla).HasMaxLength(10).IsOptional();
			Property(d => d.Descricao).HasMaxLength(500).IsOptional();

		}

	}
}