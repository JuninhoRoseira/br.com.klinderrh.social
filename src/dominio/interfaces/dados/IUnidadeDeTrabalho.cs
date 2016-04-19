using KlinderRH.Social.Dominio.Entidades;
using KlinderRH.Social.Dominio.Interfaces.Dados.Repositorios;

namespace KlinderRH.Social.Dominio.Interfaces.Dados
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