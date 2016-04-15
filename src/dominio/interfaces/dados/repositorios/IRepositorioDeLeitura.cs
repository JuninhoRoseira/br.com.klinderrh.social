using System;
using System.Linq;
using System.Linq.Expressions;
using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.dominio.interfaces.dados.repositorios
{
	public interface IRepositorioDeLeitura<T> where T : EntidadeBase
	{
		T ObterPorId(Guid id);
		IQueryable<T> ObterPor(Expression<Func<T, bool>> condicao = null, params Expression<Func<T, object>>[] dependencias);
	}
}