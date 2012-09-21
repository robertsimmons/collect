using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client.Document;
using Collect.Web.Domain.Entities;

namespace Collect.Web.ListAllFigures
{
	public class ListFiguresController
	{
		public ListFiguresViewModel ListFigures(ListFiguresInputModel input)
		{
			var result = new ListFiguresViewModel();

			using (var documentStore = new DocumentStore { Url = "http://localhost:8080" })
			{
				documentStore.Initialize();

				using (var documentSession = documentStore.OpenSession("Collect"))
				{
					result.Figures = documentSession.Query<Figure>().Select(figure => new ListFigureViewModel()
						{
							FigureName = figure.Name,
							Series = figure.Series,
							YearReleased = figure.Year
						}).ToList();
				}
			}

			return result;
		}
	}
}