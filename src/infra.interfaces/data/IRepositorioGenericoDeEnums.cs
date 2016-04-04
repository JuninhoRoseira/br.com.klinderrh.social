using System;
using System.Linq;
using System.Linq.Expressions;

namespace br.com.klinderrh.social.infra.interfaces.data
{
	public interface IRepositorioGenericoDeEnums<T> where T : class
	{
		IQueryable<T> ObterPor(Expression<Func<T, bool>> condicao = null, params Expression<Func<T, object>>[] dependencias);
	}
}