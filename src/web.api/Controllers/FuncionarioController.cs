﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using br.com.klinderrh.social.dominio.objetosdetransporte;
using br.com.klinderrh.social.infra.interfaces.aplicacao;

namespace br.com.klinderrh.social.web.api.Controllers
{

	[EnableCors("*", "*", "*")]
	[RoutePrefix("funcionarios")]
	public class FuncionarioController : ApiController
	{
		private readonly IFuncionarioAplicacao _funcionarioAplicacao;

		public FuncionarioController(IFuncionarioAplicacao funcionarioAplicacao)
		{
			_funcionarioAplicacao = funcionarioAplicacao;
		}

		[Authorize]
		[Route]
		public HttpResponseMessage Post(FuncionarioModelo funcionario)
		{

			if (funcionario == null)
				return Request.CreateResponse(HttpStatusCode.BadRequest);

			try
			{
				var novoFuncionatrio = _funcionarioAplicacao.Adicionar(funcionario);

				return Request.CreateResponse(HttpStatusCode.Created, novoFuncionatrio);

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir funcionário.");
			}

		}

	}

}