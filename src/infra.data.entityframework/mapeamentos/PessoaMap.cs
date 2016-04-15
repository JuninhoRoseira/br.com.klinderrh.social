using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
{
	public class PessoaMap : MapeamentoBase<Pessoa>
	{
		public PessoaMap()
		{
			ToTable("Pessoa");

			Property(e => e.Nome).HasMaxLength(100).IsRequired().HasColumnAnnotation("Index", NovoIndice("IX_Pessoa_Nome"));
			Property(e => e.CPF).HasMaxLength(20).IsRequired();
			Property(e => e.RG).HasMaxLength(20).IsRequired();
			Property(e => e.DataDeNascimento).IsRequired();

			HasOptional(p => p.Usuario)
				.WithMany()
				.HasForeignKey(p => p.UsuarioId);

			HasMany(p => p.Enderecos)
				.WithMany()
				.Map(mc =>
				{
					mc.ToTable("PessoasXEnderecos");
					mc.MapLeftKey("PessoaId");
					mc.MapRightKey("EnderecoId");
				});

			HasMany(p => p.Contatos)
				.WithMany()
				.Map(mc =>
				{
					mc.ToTable("PessoasXContatos");
					mc.MapLeftKey("PessoaId");
					mc.MapRightKey("ContatoId");
				});

		}

	}

}