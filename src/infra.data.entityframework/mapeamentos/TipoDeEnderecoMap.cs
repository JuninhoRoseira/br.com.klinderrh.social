using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using KlinderRH.Social.Dominio.Entidades;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Mapeamentos
{
	public class TipoDeEnderecoMap : EntityTypeConfiguration<TipoDeEnderecoEnum>
	{
		public TipoDeEnderecoMap()
		{
			ToTable("TipoDeEnderecoEnum");

			HasKey(te => te.Id);

			Property(te => te.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			Property(te => te.Nome).HasMaxLength(100).IsRequired();
			
		}

	}

}