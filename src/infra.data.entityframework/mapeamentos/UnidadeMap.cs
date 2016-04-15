using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
{
	public class UnidadeMap : MapeamentoBase<Unidade>
	{
		public UnidadeMap()
		{
			ToTable("Unidade");

			Property(e => e.RazaoSocial)
				.HasMaxLength(100)
				.IsRequired()
				.HasColumnAnnotation("Index", NovoIndice("IX_Empresa_RazaoSocial"));
			Property(e => e.NomeFantasia)
				.HasMaxLength(50)
				.IsOptional()
				.HasColumnAnnotation("Index", NovoIndice("IX_Empresa_NomeFantasia"));
			Property(e => e.CNPJ)
				.IsRequired()
				.HasColumnAnnotation("Index", NovoIndiceUnico("IX_Empresa_CNPJ"));
			Property(e => e.IE).IsRequired();

			HasRequired(u => u.Empresa)
				.WithMany(e => e.Unidades)
				.HasForeignKey(u => u.EmpresaId);

		}

	}

}