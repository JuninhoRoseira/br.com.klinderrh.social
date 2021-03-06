using KlinderRH.Social.Dominio.Entidades;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Mapeamentos
{
	public class EnderecoMap : MapeamentoBase<Endereco>
	{
		public EnderecoMap()
		{
			ToTable("Endereco");

			Property(e => e.Bairro).HasMaxLength(50).IsRequired();
			Property(e => e.CEP).HasMaxLength(8).IsRequired();
			Property(e => e.Complemento).HasMaxLength(50).IsOptional();
			Property(e => e.Logradouro).HasMaxLength(50).IsOptional();
			Property(e => e.Numero).HasMaxLength(50).IsOptional();
			Property(e => e.TipoDeEndereco).HasColumnName("TipoDeEnderecoId").IsRequired();

			HasRequired(e => e.Cidade)
				.WithMany()
				.HasForeignKey(e => e.CidadeId);

		}

	}

}