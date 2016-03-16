﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using br.com.klinderrh.social.dominio.objetosdetransporte;
using br.com.klinderrh.social.infra.interfaces.aplicacao;

namespace br.com.klinderrh.social.web.api.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[RoutePrefix("api")]
	public class AutenticacaoController : ApiController
	{
		private const string RotaPadrao = "Auth";

		private readonly IUsuarioAplicacao _usuarioAplicacao;

		public AutenticacaoController(IUsuarioAplicacao usuarioAplicacao)
		{
			_usuarioAplicacao = usuarioAplicacao;
		}

		[HttpPost]
		[Route(RotaPadrao + "/RegistrarUsuario")]
		public HttpResponseMessage RegistrarUsuario(UsuarioModelo usuario)
		{

			if (usuario == null)
				return Request.CreateResponse(HttpStatusCode.BadRequest);

			try
			{
				var novoUsuario = _usuarioAplicacao.Registrar(
					usuario.Nome,
					usuario.Email,
					usuario.Senha,
					usuario.ConfirmacaoDaSenha);

				return Request.CreateResponse(HttpStatusCode.Created, novoUsuario);

			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir tipo de inspeção");
			}

		}

	}

}