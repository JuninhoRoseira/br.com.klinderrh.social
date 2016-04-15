namespace br.com.klinderrh.social.dominio.objetosdetransporte
{
	public class DepartamentoModelo
	{
		public string Id { get; set; }
		public string Nome { get; set; }
		public string Sigla { get; set; }
		public string Descricao { get; set; }
		public string DepartamentoPaiId { get; set; }
		public string UnidadeId { get; set; }
	}
}