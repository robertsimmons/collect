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

namespace Collect.Web.App_Start
{
	public static class RavenDBStartup
	{
		public static void Bootstrap()
		{
			DocumentStoreInstance = new DocumentStore { Url = ConfigurationManager.AppSettings["RavenDbURL"] };
			DocumentStoreInstance.Initialize();

#if DEBUG
			DocumentStoreInstance.DatabaseCommands.EnsureDatabaseExists(ConfigurationManager.AppSettings["CollectionName"]);
#endif

			var catalog = new CompositionContainer(new AssemblyCatalog(typeof(SeriesLookupMapReduce).Assembly));

			IndexCreation.CreateIndexes(catalog, DocumentStoreInstance.DatabaseCommands.ForDatabase(ConfigurationManager.AppSettings["CollectionName"]), DocumentStoreInstance.Conventions);
		}

		public static DocumentStore DocumentStoreInstance; 
	}
}