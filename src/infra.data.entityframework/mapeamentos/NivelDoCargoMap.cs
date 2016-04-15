using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
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