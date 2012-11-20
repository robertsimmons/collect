using Collect.Web.Domain.Entities;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collect.Web.Lookups
{
	public class SeriesLookupMapReduce : AbstractIndexCreationTask<Figure, SeriesLookupMapReduce.ReduceResult>
	{
		public class ReduceResult
		{
			public string Series { get; set; }
			public int Count { get; set; }
		}

		public SeriesLookupMapReduce()
		{
			Map = figures => from figure in figures
							 select new { Series = figure.Series, Count = 1 };

			Reduce = results => from seriesCount in results
								group seriesCount by seriesCount.Series
									into g
									select new { Series = g.Key, Count = g.Sum(x => x.Count) };

			Index(x => x.Series, Raven.Abstractions.Indexing.FieldIndexing.Analyzed);

			Sort(result => result.Count, Raven.Abstractions.Indexing.SortOptions.Int);
		}
	}
}