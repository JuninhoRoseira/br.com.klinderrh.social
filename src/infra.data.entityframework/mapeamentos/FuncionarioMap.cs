using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.data.entityframework.mapeamentos
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
				.HasForeignKey(p => p.CodigoDaPessoa);

			HasRequired(f => f.Unidade)
				.WithMany(e => e.Funcionarios)
				.HasForeignKey(f => f.CodigoDaUnidade);

			HasRequired(f => f.Departamento)
				.WithMany()
				.HasForeignKey(f => f.CodigoDoDepartamento);

			HasRequired(f => f.Cargo)
				.WithMany()
				.HasForeignKey(f => f.CodigoDoCargo);

		}

	}

}