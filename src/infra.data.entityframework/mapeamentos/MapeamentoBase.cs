using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using KlinderRH.Social.Dominio.Entidades;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Mapeamentos
{
	public class MapeamentoBase<T> : EntityTypeConfiguration<T> where T : EntidadeBase
	{
		public MapeamentoBase()
		{
			HasKey(t => t.Id);

			Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
			Property(t => t.Ativo);
			Property(t => t.DataDeCadastro).IsOptional();

		}

		protected IndexAnnotation NovoIndice(string nomeDoIndice)
		{
			return new IndexAnnotation(new IndexAttribute(nomeDoIndice));
		}

		protected IndexAnnotation NovoIndiceUnico(string nomeDoIndice)
		{
			return new IndexAnnotation(new IndexAttribute(nomeDoIndice)
			{
				IsUnique = true
			});
		}

	}

}