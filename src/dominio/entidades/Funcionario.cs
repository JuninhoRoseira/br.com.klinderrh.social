namespace br.com.klinderrh.social.dominio.entidades
{
	public class Funcionario : EntidadeBase
	{

		protected Funcionario() { }

		public Funcionario(string matricula, int codigoDaPessoa, int codigoDaEmpresa, int codigoDoDepartamento, int codigoDoCargo) : this()
		{
			Matricula = matricula;
			CodigoDaPessoa = codigoDaPessoa;
			CodigoDaEmpresa = codigoDaEmpresa;
			CodigoDoDepartamento = codigoDoDepartamento;
			CodigoDoCargo = codigoDoCargo;
		}

		public string Matricula { get; private set; }
		
		public int CodigoDaPessoa { get; private set; }
		public Pessoa Pessoa { get; set; }

		public int CodigoDaEmpresa { get; private set; }
		public virtual Empresa Empresa { get; set; }

		public int CodigoDoDepartamento { get; private set; }
		public virtual Departamento Departamento { get; set; }

		public int CodigoDoCargo { get; private set; }
		public virtual Cargo Cargo { get; set; }

	}

}