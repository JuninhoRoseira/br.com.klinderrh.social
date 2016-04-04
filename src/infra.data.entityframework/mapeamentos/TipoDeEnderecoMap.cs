using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
{
	public class TipoDeEnderecoMap : EntityTypeConfiguration<TipoDeEnderecoEnum>
	{
		public TipoDeEnderecoMap()
		{
			ToTable("TipoDeEnderecoEnum");

			HasKey(te => te.Codigo);

			Property(te => te.Codigo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			Property(te => te.Nome).HasMaxLength(100).IsRequired();
			
		}

	}

}