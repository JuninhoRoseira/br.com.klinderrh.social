using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using KlinderRH.Social.Dominio.Entidades;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Mapeamentos
{
	public class NivelDoCargoMap : EntityTypeConfiguration<NivelDoCargoEnum>
	{
		public NivelDoCargoMap()
		{
			ToTable("NivelDoCargoEnum");

			HasKey(nc => nc.Id);

			Property(nc => nc.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			Property(nc => nc.Nome).HasMaxLength(100).IsRequired();

		}

	}

}