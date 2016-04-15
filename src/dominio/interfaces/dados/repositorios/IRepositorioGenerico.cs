using br.com.klinderrh.social.dominio.entidades;

namespace br.com.klinderrh.social.dominio.interfaces.dados.repositorios
{
	public interface IRepositorioGenerico<T> : IRepositorioDeGravacao<T>, IRepositorioDeLeitura<T> where T : EntidadeBase
	{
		 
	}
}