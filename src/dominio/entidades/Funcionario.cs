using System;
using br.com.klinderrh.social.infra.comum;
using br.com.klinderrh.social.infra.recursos;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Funcionario : EntidadeBase
	{

		protected Funcionario() { }

		public Funcionario(string matricula, Guid pessoaId, Guid unidadeId, Guid departamentoId, Guid cargoId) : this()
		{
			AlterarDados(matricula, pessoaId, unidadeId, departamentoId, cargoId);
		}

		private void AlterarDados(string matricula, Guid pessoaId, Guid unidadeId, Guid departamentoId, Guid cargoId)
		{
			Matricula = matricula;
			PessoaId = pessoaId;
			UnidadeId = unidadeId;
			DepartamentoId = departamentoId;
			CargoId = cargoId;

			Validar();

		}

		private void Validar()
		{
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Matricula, string.Format(Messages.NotBeEmpty, "Matricula"));
			//Assertions<NullReferenceException>.IsGreaterOrEquasTo(PessoaId, 1, string.Format(Messages.NotGreaterOrEqualTo, "Pessoa", "1"));
			//Assertions<NullReferenceException>.IsGreaterOrEquasTo(UnidadeId, 1,  string.Format(Messages.NotGreaterOrEqualTo, "Unidade", "1"));
			//Assertions<NullReferenceException>.IsGreaterOrEquasTo(DepartamentoId, 1, string.Format(Messages.NotGreaterOrEqualTo, "Departamento", "1"));
			//Assertions<NullReferenceException>.IsGreaterOrEquasTo(CargoId, 1, string.Format(Messages.NotGreaterOrEqualTo, "Cargo", "1"));
		}

		public string Matricula { get; private set; }

		public Guid PessoaId { get; private set; }
		public Pessoa Pessoa { get; set; }

		public Guid UnidadeId { get; private set; }
		public virtual Unidade Unidade { get; set; }

		public Guid DepartamentoId { get; private set; }
		public virtual Departamento Departamento { get; set; }

		public Guid CargoId { get; private set; }
		public virtual Cargo Cargo { get; set; }

	}

}