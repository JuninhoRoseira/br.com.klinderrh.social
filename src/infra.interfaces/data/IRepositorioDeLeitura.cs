using System;
using System.Linq;
using System.Linq.Expressions;
using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.infra.interfaces.data
{
	public interface IRepositorioDeLeitura<T> where T : EntidadeBase
	{
		T ObterPorCodigo(int codigo);
		IQueryable<T> ObterPor(Expression<Func<T, bool>> condicao = null, params Expression<Func<T, object>>[] dependencias);
	}
}