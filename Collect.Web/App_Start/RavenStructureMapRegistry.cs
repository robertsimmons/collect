using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Configuration.DSL;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;
using Raven.Client.Indexes;
using System.Reflection;

namespace Collect.Web.App_Start
{
	public class RavenStructureMapRegistry : Registry
	{
		public RavenStructureMapRegistry()
		{
			//TODO: Get from config
			var documentStore = new DocumentStore { Url = "http://localhost:8080" };
			documentStore.Initialize();

			//TODO: Remove before production
			documentStore.DatabaseCommands.EnsureDatabaseExists("Collect");

			IndexCreation.CreateIndexes(Assembly.GetCallingAssembly(), documentStore);

			//TODO: Get collection name from config
			For<IDocumentSession>().Use(() => documentStore.OpenSession("Collect"));

			//TODO: Find out if this is required...works without it, but may be doing Bad Things.
			//For<IDocumentStore>().Singleton().Use(documentStore);
		}
	}
}