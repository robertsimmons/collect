using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client.Document;
using Collect.Web.Domain.Entities;

namespace Collect.Web.AddFigures
{
	public class AddFigureController
	{
		public AddFigureViewModel AddFigure(AddFigureInputModel input)
		{
			return new AddFigureViewModel();
		}

		public AddFigureViewModel AddFigurePosted(AddFigurePostInputModel input)
		{
			if (input.FigureName == "fail")
			{
				return new AddFigureViewModel()
				{
					StatusMessage = "ONOUDINT",
					FigureName = "you're a failure"
				};
			}

			using (var documentStore = new DocumentStore { Url = "http://localhost:8080" })
			{
				documentStore.Initialize();

				using (var documentSession = documentStore.OpenSession("Collect"))
				{
					documentSession.Store(new Figure()
						{
							Id = new Guid(),
							Name = input.FigureName,
							Year = input.YearReleased,
							Series = input.Series
						});
					documentSession.SaveChanges();
				}
			}

			return new AddFigureViewModel();
		}
	}
}