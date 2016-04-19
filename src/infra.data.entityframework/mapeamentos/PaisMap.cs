using KlinderRH.Social.Dominio.Entidades;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Mapeamentos
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