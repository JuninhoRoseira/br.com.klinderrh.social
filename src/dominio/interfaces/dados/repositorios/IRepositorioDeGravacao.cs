using System;
using KlinderRH.Social.Dominio.Entidades;

namespace KlinderRH.Social.Dominio.Interfaces.Dados.Repositorios
{
	public interface IRepositorioDeGravacao<T> where T : EntidadeBase
	{
		void Incluir(T entidade);
		void Alterar(T entidade);
		void Excluir(T entidade);
		void ExcluirPor(Func<T, bool> condicao);
	}
}