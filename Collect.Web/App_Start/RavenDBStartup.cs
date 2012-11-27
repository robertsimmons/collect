using Raven.Client.Document;
using Raven.Client.Indexes;
using Raven.Client.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Reflection;
using Raven.Client;
using System.ComponentModel.Composition.Hosting;
using Collect.Web.Lookups;
using System.Diagnostics;
using System.IO;

namespace Collect.Web.App_Start
{
	public static class RavenDBStartup
	{
		public static void Bootstrap()
		{
#if DEBUG
			EnsureRavenDbServerIsRunning();
#endif

			DocumentStoreInstance = new DocumentStore { Url = ConfigurationManager.AppSettings["RavenDbURL"] };
			DocumentStoreInstance.Initialize();

#if DEBUG
			DocumentStoreInstance.DatabaseCommands.EnsureDatabaseExists(ConfigurationManager.AppSettings["CollectionName"]);
#endif

			var catalog = new CompositionContainer(new AssemblyCatalog(typeof(SeriesLookupIndex).Assembly));

			IndexCreation.CreateIndexes(catalog, DocumentStoreInstance.DatabaseCommands.ForDatabase(ConfigurationManager.AppSettings["CollectionName"]), DocumentStoreInstance.Conventions);
		}

		private static void EnsureRavenDbServerIsRunning()
		{
			var ravenExeName = "Raven.Server";

			if (Process.GetProcessesByName(ravenExeName).Length > 0)
			{
				return;
			}

			var currentDir = AppDomain.CurrentDomain.BaseDirectory;
			var ravenServerRelativeDirectory = @"..\packages\RavenDB.Server.1.2.2150-Unstable\tools";

			var fullPath = Path.Combine(currentDir, ravenServerRelativeDirectory);
			Process.Start(Path.Combine(fullPath, ravenExeName + ".exe"));
		}

		public static DocumentStore DocumentStoreInstance; 
	}
}