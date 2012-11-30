using NUnit.Framework;
using Raven.Client;
using Raven.Client.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collect.Web.Tests
{
	[SetUpFixture]
	public class SetUp
	{
		public static IDocumentStore DocumentStore;

		[SetUp]
		public static void SetUpDocumentStore()
		{
			DocumentStore = new EmbeddableDocumentStore()
			{
				Configuration =
				{
					RunInMemory = true,
					RunInUnreliableYetFastModeThatIsNotSuitableForProduction = true
				}
			};
			DocumentStore.Initialize();
		}
	}
}
