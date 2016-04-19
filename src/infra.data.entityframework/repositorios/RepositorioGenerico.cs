using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using KlinderRH.Social.Dominio.Entidades;
using KlinderRH.Social.Dominio.Interfaces.Dados.Repositorios;

namespace KlinderRH.Social.Infra.Data.EntityFramework.Repositorios
{
	public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : EntidadeBase
	{
		private readonly DbContext _contexto;
		private readonly DbSet<T> _dbSet;

		public RepositorioGenerico(DbContext contexto)
		{
			_contexto = contexto;
			_dbSet = _contexto.Set<T>();
		}

		public void Incluir(T entidade)
		{
			_dbSet.Add(entidade);
		}

		public void Alterar(T entidade)
		{
			throw new NotImplementedException();
		}

		public void Excluir(T entidade)
		{
			throw new NotImplementedException();
		}

		public void ExcluirPor(Func<T, bool> condicao)
		{
			throw new NotImplementedException();
		}

		public T ObterPorId(Guid id)
		{
			return _dbSet.FirstOrDefault(s => s.Id == id);
		}

		public IQueryable<T> ObterPor(Expression<Func<T, bool>> condicao = null,
			params Expression<Func<T, object>>[] dependencias)
		{
			var query = condicao != null
				? _dbSet.AsNoTracking().Where(condicao)
				: _dbSet.AsNoTracking();

			query = dependencias.Aggregate(query,
				(current, include) => current.Include(include));

			return query;

		}

	}

}