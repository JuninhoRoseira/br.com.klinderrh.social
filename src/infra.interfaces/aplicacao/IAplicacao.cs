﻿using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.dominio.objetosdetransporte;

namespace br.com.klinderrh.social.infra.interfaces.aplicacao
{

	public interface IUsuarioAplicacao
	{
		Usuario Registrar(UsuarioModelo usuario);
		Usuario Autenticar(UsuarioModelo usuario);
	}

	public interface IFuncionarioAplicacao
	{
		Funcionario Adicionar(FuncionarioModelo funcionario);
	}

	public interface IPessoaAplicacao
	{
		Pessoa Adicionar(PessoaModelo pessoa);
	}

	public interface ICargoAplicacao
	{
		Cargo Adicionar(CargoModelo cargo);
		void Modificar(CargoModelo cargo);
	}

}