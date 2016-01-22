using System;
using System.Collections;
using System.Data.Entity;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.infra.data.entityframework.repositorios;
using br.com.klinderrh.social.infra.interfaces.data;

namespace br.com.klinderrh.social.infra.data.entityframework
{
	public class UnidadeDeTrabalho : IUnidadeDeTrabalho
	{

		private readonly DbContext _contexto;
		private DbContextTransaction _transaction;
		private bool _disposed;
		private Hashtable _repositories;

		public UnidadeDeTrabalho(DbContext contexto)
		{
			_contexto = contexto;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_contexto.Dispose();
				}
			}
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void Salvar()
		{
			_contexto.SaveChanges();
			_transaction.Commit();
		}

		public void IniciarTransacao()
		{
			_transaction = _contexto.Database.BeginTransaction();
		}

		public void DescartarTransacao()
		{
			_transaction.Rollback();
		}

		public IRepositorioGenerico<T> ObterRepositorio<T>() where T : EntidadeBase
		{
			if (_repositories == null)
				_repositories = new Hashtable();

			var type = typeof(T).Name;

			if (!_repositories.ContainsKey(type))
			{
				var repositoryType = typeof(RepositorioGenerico<>);

				var repositoryInstance =
					Activator.CreateInstance(repositoryType
						.MakeGenericType(typeof(T)), _contexto);

				_repositories.Add(type, repositoryInstance);
			}

			return (IRepositorioGenerico<T>)_repositories[type];

		}

	}

}