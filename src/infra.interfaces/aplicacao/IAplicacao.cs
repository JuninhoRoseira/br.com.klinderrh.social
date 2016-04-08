﻿using System.Collections.Generic;
using br.com.klinderrh.social.dominio.entidades;
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
		void Excluir(int codigo);
		List<Cargo> ObterTodos();
		List<Cargo> ObterTodosOsAtivos();
		List<Cargo> ProcurarCargosPorTexto(string textoDaBusca);
		Cargo ObterPorCodigo(int codigo);
		List<NivelDoCargoEnum> ObterNiveis();
	}

	public interface IDepartamentoAplicacao
	{
		Departamento Adicionar(DepartamentoModelo departamento);
		void Modificar(DepartamentoModelo departamento);
		void Excluir(int codigo);
		List<Departamento> ObterTodos();
		List<Departamento> ObterTodosOsAtivos();
		List<Departamento> ProcurarDepartamentosPorTexto(string textoDaBusca);
		Departamento ObterPorCodigo(int codigo);
	}

}