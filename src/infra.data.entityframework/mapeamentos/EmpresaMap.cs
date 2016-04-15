using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
{
	public class EmpresaMap : MapeamentoBase<Empresa>
	{
		public EmpresaMap()
		{
			ToTable("Empresa");

			Property(e => e.RazaoSocial)
				.HasMaxLength(100)
				.IsRequired()
				.HasColumnAnnotation("Index", NovoIndice("IX_Empresa_RazaoSocial"));
			Property(e => e.NomeFantasia)
				.HasMaxLength(50)
				.IsOptional()
				.HasColumnAnnotation("Index", NovoIndice("IX_Empresa_NomeFantasia"));
			Property(e => e.CNPJ)
				.HasMaxLength(20)
				.IsRequired()
				.HasColumnAnnotation("Index", NovoIndiceUnico("IX_Empresa_CNPJ"));
			Property(e => e.IE)
				.HasMaxLength(20)
				.IsRequired();
			Property(e => e.DataDeAdesao).IsRequired();

			HasMany(p => p.Enderecos)
				.WithMany()
				.Map(mc =>
				{
					mc.ToTable("EmpresasXEnderecos");
					mc.MapLeftKey("EmpresaId");
					mc.MapRightKey("EnderecoId");
				});

			HasMany(p => p.Contatos)
				.WithMany()
				.Map(mc =>
				{
					mc.ToTable("EmpresasXContatos");
					mc.MapLeftKey("EmpresaId");
					mc.MapRightKey("ContatoId");
				});

		}

	}

}