using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.interfaces.data
{
	public interface IUnidadeDeTrabalho // : IDisposable
	{
		bool IniciarTransacao();
		void EfetivarTransacao(bool executar);
		void DescartarTransacao(bool executar);
		void Salvar();
		IRepositorioGenerico<T> ObterRepositorio<T>() where T : EntidadeBase;
	}
}