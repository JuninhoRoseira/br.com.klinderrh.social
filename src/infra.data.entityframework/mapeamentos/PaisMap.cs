using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
{
	public class PaisMap : MapeamentoBase<Pais>
	{
		public PaisMap()
		{
			ToTable("Pais");

			Property(p => p.Nome).HasMaxLength(100).IsRequired().HasColumnAnnotation("Index", NovoIndice("IX_Pais_Nome"));
			
		}

	}

}