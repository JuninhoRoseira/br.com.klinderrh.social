using System;
using br.com.klinderrh.social.infra.comum;
using br.com.klinderrh.social.infra.recursos;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Funcionario : EntidadeBase
	{

		protected Funcionario() { }

		public Funcionario(string matricula, int codigoDaPessoa, int codigoDaUnidade, int codigoDoDepartamento, int codigoDoCargo) : this()
		{
			AlterarDados(matricula, codigoDaPessoa, codigoDaUnidade, codigoDoDepartamento, codigoDoCargo);
		}

		private void AlterarDados(string matricula, int codigoDaPessoa, int codigoDaUnidade, int codigoDoDepartamento, int codigoDoCargo)
		{
			Matricula = matricula;
			CodigoDaPessoa = codigoDaPessoa;
			CodigoDaUnidade = codigoDaUnidade;
			CodigoDoDepartamento = codigoDoDepartamento;
			CodigoDoCargo = codigoDoCargo;

			Validar();

		}

		private void Validar()
		{
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Matricula, string.Format(Messages.NotBeEmpty, "Matricula"));
			Assertions<NullReferenceException>.IsGreaterOrEquasTo(CodigoDaPessoa, 1, string.Format(Messages.NotGreaterOrEqualTo, "Pessoa", "1"));
			Assertions<NullReferenceException>.IsGreaterOrEquasTo(CodigoDaUnidade, 1,  string.Format(Messages.NotGreaterOrEqualTo, "Unidade", "1"));
			Assertions<NullReferenceException>.IsGreaterOrEquasTo(CodigoDoDepartamento, 1, string.Format(Messages.NotGreaterOrEqualTo, "Departamento", "1"));
			Assertions<NullReferenceException>.IsGreaterOrEquasTo(CodigoDoCargo, 1, string.Format(Messages.NotGreaterOrEqualTo, "Cargo", "1"));
		}

		public string Matricula { get; private set; }

		public int CodigoDaPessoa { get; private set; }
		public Pessoa Pessoa { get; set; }

		public int CodigoDaUnidade { get; private set; }
		public virtual Unidade Unidade { get; set; }

		public int CodigoDoDepartamento { get; private set; }
		public virtual Departamento Departamento { get; set; }

		public int CodigoDoCargo { get; private set; }
		public virtual Cargo Cargo { get; set; }

	}

}