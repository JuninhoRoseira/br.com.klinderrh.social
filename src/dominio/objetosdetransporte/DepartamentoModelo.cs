﻿namespace br.com.klinderrh.social.dominio.objetosdetransporte
{
	public class DepartamentoModelo
	{
		public string Codigo { get; set; }
		public string Nome { get; set; }
		public string Sigla { get; set; }
		public string Descricao { get; set; }
		public string CodigoDoDepartamentoPai { get; set; }
		public string CodigoDaUnidade { get; set; }
	}
}