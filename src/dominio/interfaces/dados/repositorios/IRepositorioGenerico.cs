using KlinderRH.Social.Dominio.Entidades;

namespace KlinderRH.Social.Dominio.Interfaces.Dados.Repositorios
{
	public interface IRepositorioGenerico<T> : IRepositorioDeGravacao<T>, IRepositorioDeLeitura<T> where T : EntidadeBase
	{
		 
	}
}