using FubuMVC.Core;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collect.Web.Lookups
{
	public class TagLookupController
	{
		private readonly IDocumentSession _documentSession;

		public TagLookupController(IDocumentSession documentSession)
		{
			_documentSession = documentSession;
		}

		[JsonEndpoint]
		public string[] TagLookup(TagLookupInputModel input)
		{
			if(string.IsNullOrEmpty(input.term))
			{
				input.term = "";
			}

			if (string.IsNullOrEmpty(input.used))
			{
				input.used = "";
			}

			var usedTags = input.used.Split(',');
			
			//TODO: limit results
			var results = _documentSession.Query<TagLookupIndex.ReduceResult, TagLookupIndex>()
							.Where(x => x.Tag.StartsWith(input.term))
							.Select(x => x.Tag).ToList();
			var trimmedResults = results.Where(tag => !usedTags.Contains(tag));

			return trimmedResults.ToArray();
		}
	}
}