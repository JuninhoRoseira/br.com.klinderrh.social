using br.com.klinderrh.social.aplicacao;
using br.com.klinderrh.social.infra.data.entityframework;
using br.com.klinderrh.social.infra.interfaces;
using br.com.klinderrh.social.infra.interfaces.aplicacao;
using br.com.klinderrh.social.infra.interfaces.data;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace br.com.klinderrh.social.infra.ioc
{
	// GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

	public class IoC
	{
		public IoC()
		{
			Kernel = new StandardKernel(
				new DataBindings(),
				new ApplicationBindings());
		}

		public IKernel Kernel { get; private set; }

	}

	public class DataBindings : NinjectModule
	{
		public override void Load()
		{
			Bind<Contexto>().ToSelf().InSingletonScope();
			Bind<IUnidadeDeTrabalho>().To<UnidadeDeTrabalho>().InRequestScope();
			Bind<IAuthorizationServerProvider>().To<AuthorizationServerProvider>();
		}
	}

	public class ApplicationBindings : NinjectModule
	{
		public override void Load()
		{
			Bind<IUsuarioAplicacao>().To<UsuarioAplicacao>();
			Bind<IPessoaAplicacao>().To<PessoaAplicacao>();
			Bind<IFuncionarioAplicacao>().To<FuncionarioAplicacao>();
			Bind<ICargoAplicacao>().To<CargoAplicacao>();
		}
	}

}