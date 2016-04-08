using System;
using System.Collections.Generic;
using br.com.klinderrh.social.infra.comum;
using br.com.klinderrh.social.infra.recursos;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Departamento : EntidadeBase
	{

		protected Departamento()
		{
			DepartamentosFilho = new List<Departamento>();
		}

		public Departamento(string nome, string sigla, string descricao, int codigoDaUnidade, int? codigoDoDepartamentoPai) : this()
		{
			AlterarDados(nome, sigla, descricao, codigoDaUnidade, codigoDoDepartamentoPai);
		}

		public string Nome { get; private set; }
		public string Sigla { get; private set; }
		public string Descricao { get; private set; }

		public int? CodigoDoDepartamentoPai { get; private set; }
		public virtual Departamento DepartamentoPai { get; set; }

		public int CodigoDaUnidade { get; private set; }
		public virtual Unidade Unidade { get; set; }

		public virtual ICollection<Departamento> DepartamentosFilho { get; set; }

		public void AlterarDados(string nome, string sigla, string descricao, int codigoDaUnidade, int? codigoDoDepartamentoPai)
		{
			Nome = nome;
			Sigla = sigla;
			Descricao = descricao;
			CodigoDaUnidade = codigoDaUnidade;
			CodigoDoDepartamentoPai = codigoDoDepartamentoPai;

			Validar();

		}

		private void Validar()
		{
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Nome, string.Format(Messages.NotBeEmpty, "Nome"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Sigla, string.Format(Messages.NotBeEmpty, "Sigla"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Descricao, string.Format(Messages.NotBeEmpty, "Descricao"));
			Assertions<NullReferenceException>.IsGreaterOrEquasTo(CodigoDaUnidade, 1, string.Format(Messages.NotGreaterOrEqualTo, "Unidade", "1"));
		}

	}

}