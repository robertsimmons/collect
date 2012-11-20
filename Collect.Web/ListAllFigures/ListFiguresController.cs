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
			var result = new ListFiguresViewModel();

			result.Figures = _documentSession.Query<Figure>().Select(figure => new ListFigureViewModel()
				{
					FigureName = figure.Name,
					Series = figure.Series,
					YearReleased = figure.Year,
					Id = figure.Id
				}).ToList();

			return result;
		}
	}
}