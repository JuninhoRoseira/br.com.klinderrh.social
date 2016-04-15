using System;
using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.dominio.interfaces.dados.repositorios
{
	public interface IRepositorioDeGravacao<T> where T : EntidadeBase
	{
		void Incluir(T entidade);
		void Alterar(T entidade);
		void Excluir(T entidade);
		void ExcluirPor(Func<T, bool> condicao);
	}
}