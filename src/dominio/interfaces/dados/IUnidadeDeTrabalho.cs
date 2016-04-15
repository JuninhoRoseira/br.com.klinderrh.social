using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.dominio.interfaces.dados.repositorios;

namespace br.com.klinderrh.social.dominio.interfaces.dados
{
	public interface IUnidadeDeTrabalho // : IDisposable
	{
		bool IniciarTransacao();
		void EfetivarTransacao(bool executar);
		void DescartarTransacao(bool executar);
		void Salvar();
		IRepositorioGenerico<T> ObterRepositorio<T>() where T : EntidadeBase;
		IRepositorioGenericoDeEnums<T> ObterRepositorioDeEnums<T>() where T : class;
	}
}