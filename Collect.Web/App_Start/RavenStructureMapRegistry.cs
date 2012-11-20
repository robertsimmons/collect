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
using System.Configuration;

namespace Collect.Web.App_Start
{
	public class RavenStructureMapRegistry : Registry
	{
		public RavenStructureMapRegistry()
		{
			For<IDocumentSession>().Use(() => RavenDBStartup.DocumentStoreInstance.OpenSession(ConfigurationManager.AppSettings["CollectionName"]));

			//TODO: Find out if this is required...works without it, but may be doing Bad Things.
			//For<IDocumentStore>().Singleton().Use(documentStore);
		}
	}
}