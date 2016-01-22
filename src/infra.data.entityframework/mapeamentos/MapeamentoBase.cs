using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
{
	public class MapeamentoBase<T> : EntityTypeConfiguration<T> where T : EntidadeBase
	{
		public MapeamentoBase()
		{
			HasKey(t => t.Codigo);

			Property(t => t.Codigo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
			Property(t => t.Ativo);
			Property(t => t.DataDeCadastro).IsOptional();

		}

		protected IndexAnnotation NovoIndice(string nomeDoIndice)
		{
			return new IndexAnnotation(new IndexAttribute(nomeDoIndice));
		}

	}

}