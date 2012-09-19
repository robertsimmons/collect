using Collect.Web.Controllers;
using FubuMVC.Core;
using FubuMVC.Razor;

namespace Collect.Web
{
	public class ConfigureFubuMVC : FubuRegistry
	{
		public ConfigureFubuMVC()
		{
			// This line turns on the basic diagnostics and request tracing
			IncludeDiagnostics(true);

			// All public methods from concrete classes ending in "Controller"
			// in this assembly are assumed to be action methods
			Actions.IncludeClassesSuffixedWithController();

			// Policies
			Routes
				.HomeIs<HelloInputModel>()
				.IgnoreControllerNamesEntirely()
				.IgnoreControllerNamespaceEntirely()
				.IgnoreMethodSuffix("Html")
				.RootAtAssemblyNamespace();

			Import<RazorEngineRegistry>();

			// Match views to action methods by matching
			// on model type, view name, and namespace
			Views.TryToAttachWithDefaultConventions();
		}
	}
}