using KlinderRH.Social.Dominio.Entidades;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Mapeamentos
{
	public class DepartamentoMap : MapeamentoBase<Departamento>
	{
		public DepartamentoMap()
		{
			ToTable("Departamento");

			Property(d => d.Nome).HasMaxLength(50).IsRequired();
			Property(d => d.Sigla).HasMaxLength(10).IsOptional();
			Property(d => d.Descricao).HasMaxLength(500).IsOptional();

			HasOptional(d => d.DepartamentoPai)
				.WithMany(d => d.DepartamentosFilho)
				.HasForeignKey(d => d.DepartamentoPaiId);

		}

	}

}