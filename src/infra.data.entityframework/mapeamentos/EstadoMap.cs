using KlinderRH.Social.Dominio.Entidades;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Mapeamentos
{
	public class EstadoMap : MapeamentoBase<Estado>
	{
		public EstadoMap()
		{
			ToTable("Estado");

			Property(e => e.Nome).HasMaxLength(100).IsRequired().HasColumnAnnotation("Index", NovoIndice("IX_Estado_Nome"));
			Property(e => e.UnidadeFederativa).HasMaxLength(2).IsRequired();

			HasRequired(e => e.Pais)
				.WithMany(p => p.Estados)
				.HasForeignKey(e => e.PaisId);

		}

	}

}