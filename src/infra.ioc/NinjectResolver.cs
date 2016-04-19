using System.Reflection;
using System.Web.Http.Dependencies;
using Ninject;

namespace KlinderRH.Social.Infra.IoC
{
	public class NinjectResolver : NinjectScope, IDependencyResolver
	{
		private readonly IKernel _kernel;

		public NinjectResolver(IKernel kernel) : base(kernel)
		{
			_kernel = kernel;
		}

		public IDependencyScope BeginScope()
		{
			return new NinjectScope(_kernel.BeginBlock());
		}

		public void Load(Assembly assembly)
		{
			_kernel.Load(assembly);
		}
		public T Get<T>()
		{
			return _kernel.Get<T>();
		}

	}

}