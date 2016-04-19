using KlinderRH.Social.Dominio.Entidades;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Mapeamentos
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