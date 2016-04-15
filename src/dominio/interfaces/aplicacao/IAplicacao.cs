using System;
using System.Collections.Generic;
using br.com.klinderrh.social.dominio.entidades;
using br.com.klinderrh.social.dominio.objetosdetransporte;

namespace br.com.klinderrh.social.dominio.interfaces.aplicacao
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
		void Excluir(Guid id);
		List<Cargo> ObterTodos();
		List<Cargo> ObterTodosOsAtivos();
		List<Cargo> ProcurarCargosPorTexto(string textoDaBusca);
		Cargo ObterPorId(Guid id);
		List<NivelDoCargoEnum> ObterNiveis();
	}

	public interface IDepartamentoAplicacao
	{
		Departamento Adicionar(DepartamentoModelo departamento);
		void Modificar(DepartamentoModelo departamento);
		void Excluir(Guid id);
		List<Departamento> ObterTodos();
		List<Departamento> ObterTodosOsAtivos();
		List<Departamento> ProcurarDepartamentosPorTexto(string textoDaBusca);
		Departamento ObterPorId(Guid id);
	}

}