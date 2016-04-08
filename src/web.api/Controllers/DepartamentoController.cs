using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using br.com.klinderrh.social.dominio.objetosdetransporte;
using br.com.klinderrh.social.infra.interfaces.aplicacao;

namespace br.com.klinderrh.social.web.api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[EnableCors("*", "*", "*")]
	[RoutePrefix("Departamentos")]
	public class DepartamentoController : ApiController
	{
		private readonly IDepartamentoAplicacao _departamentoAplicacao;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="departamentoAplicacao"></param>
		public DepartamentoController(IDepartamentoAplicacao departamentoAplicacao)
		{
			_departamentoAplicacao = departamentoAplicacao;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Authorize]
		[Route]
		public HttpResponseMessage Get()
		{
			try
			{
				var departamentosAtivos = _departamentoAplicacao.ObterTodosOsAtivos();

				return Request.CreateResponse(HttpStatusCode.OK, departamentosAtivos);

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao obter Departamentos.");
			}

		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="codigo"></param>
		/// <returns></returns>
		[Authorize]
		[Route("{codigo:int}")]
		public HttpResponseMessage Get(int codigo)
		{
			try
			{
				var departamento = _departamentoAplicacao.ObterPorCodigo(codigo);

				return Request.CreateResponse(HttpStatusCode.OK, departamento);

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao obter Departamento.");
			}

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="textoDaBusca"></param>
		/// <returns></returns>
		[Authorize]
		[Route("{textoDaBusca}")]
		public HttpResponseMessage Get(string textoDaBusca)
		{
			try
			{
				var departamentos = _departamentoAplicacao.ProcurarDepartamentosPorTexto(textoDaBusca);

				return Request.CreateResponse(HttpStatusCode.OK, departamentos);

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao obter Departamento.");
			}

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="departamento"></param>
		/// <returns></returns>
		[Authorize]
		[Route]
		public HttpResponseMessage Post(DepartamentoModelo departamento)
		{
			if (departamento == null)
				return Request.CreateResponse(HttpStatusCode.BadRequest);

			try
			{
				var novoFuncionatrio = _departamentoAplicacao.Adicionar(departamento);

				return Request.CreateResponse(HttpStatusCode.Created, novoFuncionatrio);

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir Departamento.");
			}

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="departamento"></param>
		/// <returns></returns>
		[Authorize]
		[Route]
		public HttpResponseMessage Put(DepartamentoModelo departamento)
		{
			if (departamento == null)
				return Request.CreateResponse(HttpStatusCode.BadRequest);

			try
			{
				_departamentoAplicacao.Modificar(departamento);

				return Request.CreateResponse(HttpStatusCode.OK, "Departamento modificado com sucesso.");

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao modificar Departamento.");
			}

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="codigo"></param>
		/// <returns></returns>
		[Authorize]
		[Route("{codigo:int}")]
		public HttpResponseMessage Delete(int codigo)
		{
			try
			{
				_departamentoAplicacao.Excluir(codigo);

				return Request.CreateResponse(HttpStatusCode.OK, "Departamento excluído com sucesso.");

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir Departamento.");
			}

		}

	}

}