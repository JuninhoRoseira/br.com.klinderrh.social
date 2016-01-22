using System;
using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.interfaces.data
{
	public interface IUnidadeDeTrabalho : IDisposable
	{
		void IniciarTransacao();
		void Salvar();
		void DescartarTransacao();
		IRepositorioGenerico<T> ObterRepositorio<T>() where T : EntidadeBase;
	}
}