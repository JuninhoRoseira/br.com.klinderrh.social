using KlinderRH.Social.Dominio.Entidades;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Mapeamentos
{
	public class FuncionarioMap : MapeamentoBase<Funcionario>
	{
		public FuncionarioMap()
		{
			
			ToTable("Funcionario");

			Property(c => c.Matricula)
				.HasMaxLength(50)
				.IsRequired()
				.HasColumnAnnotation("Index", NovoIndiceUnico("IX_Funcionario_Matricula"));

			HasRequired(p => p.Pessoa)
				.WithMany()
				.HasForeignKey(p => p.PessoaId);

			HasRequired(f => f.Unidade)
				.WithMany(e => e.Funcionarios)
				.HasForeignKey(f => f.UnidadeId);

			HasRequired(f => f.Departamento)
				.WithMany()
				.HasForeignKey(f => f.DepartamentoId);

			HasRequired(f => f.Cargo)
				.WithMany()
				.HasForeignKey(f => f.CargoId);

		}

	}

}