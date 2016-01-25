using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
{
	public class ContatoMap : MapeamentoBase<Contato>
	{
		public ContatoMap()
		{
			ToTable("Contato");

			Property(c => c.Email).HasMaxLength(50).IsRequired();
			Property(c => c.Telefone).HasMaxLength(50).IsOptional();

		}

	}
}