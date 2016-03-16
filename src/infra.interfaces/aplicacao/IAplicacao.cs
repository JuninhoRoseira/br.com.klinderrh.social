using System;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.dominio.objetosdetransporte;

namespace br.com.klinderrh.social.infra.interfaces.aplicacao
{

	public interface IUsuarioAplicacao
	{
		Usuario Registrar(string nome, string email, string senha, string confirmacaoDaSenha);
		Usuario Autenticar(string email, string senha);
	}

	public interface IFuncionarioAplicacao
	{
		Funcionario Adicionar(FuncionarioModelo funcionario);
	}

	public interface IPessoaAplicacao
	{
		Pessoa Adicionar(string nome, string rg, string cpf, DateTime dataDeNascimento, int codigoDoUsuario);
	}

}