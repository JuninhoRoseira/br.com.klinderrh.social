using System;
using System.Collections.Generic;
using KlinderRH.Social.Infra.Comum;
using KlinderRH.Social.Infra.Recursos;

namespace KlinderRH.Social.Dominio.Entidades
{
	public class Empresa : EntidadeBase
	{
		protected Empresa()
		{
			Unidades = new List<Unidade>();
			Enderecos = new List<Endereco>();
			Contatos = new List<Pessoa>();
		}

		public Empresa(string razaoSocial, string nomeFantasia, string documento, string inscricao) : this()
		{
			AlterarDados(razaoSocial, nomeFantasia, documento, inscricao);
		}

		private void AlterarDados(string razaoSocial, string nomeFantasia, string documento, string inscricao)
		{
			RazaoSocial = razaoSocial;
			NomeFantasia = nomeFantasia;
			CNPJ = documento;
			IE = inscricao;

			Validar();

		}

		private void Validar()
		{
			Assertions<NullReferenceException>.IsNotNullOrEmpty(RazaoSocial, string.Format(Messages.NotBeEmpty, "Razão Social"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(NomeFantasia, string.Format(Messages.NotBeEmpty, "Nome Fantasia"));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(CNPJ, string.Format(Messages.NotBeEmpty, "C.N.P.J."));
			Assertions<NullReferenceException>.IsNotNullOrEmpty(IE, string.Format(Messages.NotBeEmpty, "Inscrição Estadual"));
		}

		public string RazaoSocial { get; private set; }
		public string NomeFantasia { get; private set; }
		public string CNPJ { get; private set; }
		public string IE { get; private set; }
		public DateTime DataDeAdesao { get; set; }

		public virtual ICollection<Unidade> Unidades { get; set; }
		public virtual ICollection<Endereco> Enderecos { get; set; }
		public virtual ICollection<Pessoa> Contatos { get; set; }

	}

}