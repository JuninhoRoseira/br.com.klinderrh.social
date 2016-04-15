using System;
using br.com.klinderrh.social.dominio.objetosdevalor;

namespace br.com.klinderrh.social.dominio.entidades
{
	public class Endereco : EntidadeBase
	{
		public Endereco()
		{
			TipoDeEndereco = TipoDeEndereco.Residencial;
		}

		public TipoDeEndereco TipoDeEndereco { get; set; }
		public string Logradouro { get; set; }
		public string Numero { get; set; }
		public string Complemento { get; set; }
		public string CEP { get; set; }
		public string Bairro { get; set; }
		public Guid CidadeId { get; set; }
		public virtual Cidade Cidade { get; set; }

	}

}