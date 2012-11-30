using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Collect.Web.Domain.Entities;

namespace Collect.Web.ListAllFigures
{
	public class ListFiguresController
	{
		private readonly IDocumentSession _documentSession;

		public ListFiguresController(IDocumentSession documentSession)
		{
			_documentSession = documentSession;
		}

		public ListFiguresViewModel ListFigures(ListFiguresInputModel input)
		{
			//TODO: limit results / pagination
			var rawResults = _documentSession.Query<Figure>()
							.OrderBy(x => x.Name)
							.ToList();

			var result = new ListFiguresViewModel();
			result.Figures = rawResults.Select(figure => new ListFigureViewModel()
								{
									FigureName = figure.Name,
									Series = figure.Series,
									YearReleased = figure.Year,
									Id = figure.Id,
									Tags = figure.Tags.Count > 1 ? figure.Tags.Aggregate((x, y) => string.Format("{0}, {1}", x, y)) : figure.Tags.FirstOrDefault()
								})
								.ToList();

			return result;
		}
	}
}