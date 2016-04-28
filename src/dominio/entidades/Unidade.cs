using System;
using System.Collections.Generic;
using KlinderRH.Core.Comum;
using KlinderRH.Social.Infra.Recursos;

namespace KlinderRH.Social.Dominio.Entidades
{
	public class Unidade : EntidadeBase
	{
		protected Unidade()
		{
			Departamentos = new List<Departamento>();
			Funcionarios = new List<Funcionario>();
		}

		public Unidade(string razaoSocial, string nomeFantasia, string documento, string inscricao, Guid empresaId) : this()
		{
			AlterarDados(razaoSocial, nomeFantasia, documento, inscricao, empresaId);
		}

		private void AlterarDados(string razaoSocial, string nomeFantasia, string documento, string inscricao, Guid empresaId)
		{
			RazaoSocial = razaoSocial;
			NomeFantasia = nomeFantasia;
			CNPJ = documento;
			IE = inscricao;
			EmpresaId = empresaId;

			Validar();

		}

		private void Validar()
		{
			Assertions<NullReferenceException>.IsNotNullOrEmpty(RazaoSocial, string.Format(Messages.NotBeEmpty, "Razão Social"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(NomeFantasia, string.Format(Messages.NotBeEmpty, "Nome Fantasia"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(CNPJ, string.Format(Messages.NotBeEmpty, "C.N.P.J."));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(IE, string.Format(Messages.NotBeEmpty, "Inscrição Estadual"));
			// Assertions<NullReferenceException>.IsGreaterOrEquasTo(EmpresaId, 1, string.Format(Messages.NotGreaterOrEqualTo, "Empresa", "1"));
		}

		public string RazaoSocial { get; private set; }
		public string NomeFantasia { get; private set; }
		public string CNPJ { get; private set; }
		public string IE { get; private set; }

		public Guid EmpresaId { get; private set; }
		public virtual Empresa Empresa { get; set; }

		public virtual ICollection<Departamento> Departamentos { get; set; }
		public virtual ICollection<Funcionario> Funcionarios { get; set; }

	}

}