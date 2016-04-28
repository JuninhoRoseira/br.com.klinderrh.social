using System;
using System.Collections.Generic;
using KlinderRH.Core.Comum;
using KlinderRH.Social.Infra.Recursos;

namespace KlinderRH.Social.Dominio.Entidades
{
	public class Departamento : EntidadeBase
	{

		protected Departamento()
		{
			DepartamentosFilho = new List<Departamento>();
		}

		public Departamento(string nome, string sigla, string descricao, Guid unidadeId, Guid? departamentoPaiId) : this()
		{
			AlterarDados(nome, sigla, descricao, unidadeId, departamentoPaiId);
		}

		public string Nome { get; private set; }
		public string Sigla { get; private set; }
		public string Descricao { get; private set; }

		public Guid? DepartamentoPaiId { get; private set; }
		public virtual Departamento DepartamentoPai { get; set; }

		public Guid UnidadeId { get; private set; }
		public virtual Unidade Unidade { get; set; }

		public virtual ICollection<Departamento> DepartamentosFilho { get; set; }

		public void AlterarDados(string nome, string sigla, string descricao, Guid unidadeId, Guid? departamentoPaiId)
		{
			Nome = nome;
			Sigla = sigla;
			Descricao = descricao;
			UnidadeId = unidadeId;
			DepartamentoPaiId = departamentoPaiId;

			Validar();

		}

		private void Validar()
		{
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Nome, string.Format(Messages.NotBeEmpty, "Nome"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Sigla, string.Format(Messages.NotBeEmpty, "Sigla"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(Descricao, string.Format(Messages.NotBeEmpty, "Descricao"));
			//Assertions<NullReferenceException>.IsGreaterOrEquasTo(UnidadeId, 1, string.Format(Messages.NotGreaterOrEqualTo, "Unidade", "1"));
		}

	}

}