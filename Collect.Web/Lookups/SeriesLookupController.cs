using Collect.Web.Domain.Entities;
using FubuMVC.Core;
using Raven.Client;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collect.Web.Lookups
{
	public class SeriesLookupController
	{
		private readonly IDocumentSession _documentSession;

		public SeriesLookupController(IDocumentSession documentSession)
		{
			_documentSession = documentSession;
		}

		[JsonEndpoint]
		public string[] SeriesLookup(SeriesLookupInputModel input)
		{
			if(string.IsNullOrEmpty(input.term))
			{
				input.term = "";
			}
			
			//TODO: limit results
			var results = _documentSession.Query<SeriesLookupIndex.ReduceResult, SeriesLookupIndex>()
							.Where(x => x.Series.StartsWith(input.term))
							.Select(x => x.Series).ToArray();

			return results;
		}
	}
}