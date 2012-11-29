using Collect.Web.Domain.Entities;
using Collect.Web.ListAllFigures;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collect.Web.SearchFigures
{
	public class SearchFigureController
	{
		private readonly IDocumentSession _documentSession;

		public SearchFigureController(IDocumentSession documentSession)
		{
			_documentSession = documentSession;
		}

		public ListFiguresViewModel SearchFigure_SearchTerm(SearchFigureInputModel input)
		{
			//TODO: limit results
			var figures = _documentSession.Query<Figure>()
				.Where(figure => figure.Name.StartsWith(input.SearchTerm))
				.ToList()
				.Select(figure => new ListFigureViewModel()
				{
					FigureName = figure.Name,
					Id = figure.Id,
					Series = figure.Series,
					YearReleased = figure.Year
				});

			return new ListFiguresViewModel()
				{
					PageHeader = string.Format("Figures found for '{0}'", input.SearchTerm),
					Figures = figures.ToList()
				};
		}
	}
}