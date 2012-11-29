using Collect.Web.Domain.Entities;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collect.Web.Lookups
{
	public class TagLookupIndex : AbstractIndexCreationTask<Figure, TagLookupIndex.ReduceResult>
	{
		public class ReduceResult
		{
			public string Tag { get; set; }
			public int Count { get; set; }
		}

		public TagLookupIndex()
		{
			Map = figures => from figure in figures
							 from tag in figure.Tags
							 select new { Tag = tag.ToLower(), Count = 1 };

			Reduce = results => from tagCount in results
								group tagCount by tagCount.Tag
								into g
								select new { Tag = g.Key, Count = g.Sum(x => x.Count) };

			Index(x => x.Tag, Raven.Abstractions.Indexing.FieldIndexing.Analyzed);

			Sort(result => result.Count, Raven.Abstractions.Indexing.SortOptions.Int);
		}
	}
}