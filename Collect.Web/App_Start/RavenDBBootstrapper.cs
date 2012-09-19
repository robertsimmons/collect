using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client.Document;
using Raven.Client.Extensions;

namespace Collect.Web.App_Start
{
	public static class RavenDBBootstrapper
	{
		public static void Bootstrap()
		{
			using (var documentStore = new DocumentStore { Url = "http://localhost:8080" })
			{
				documentStore.Initialize();
				documentStore.DatabaseCommands.EnsureDatabaseExists("Collect");

				using (var documentSession = documentStore.OpenSession("Collect"))
				{
					documentSession.SaveChanges();
				}
			}
		}
	}
}