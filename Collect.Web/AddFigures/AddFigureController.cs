using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Collect.Web.Domain.Entities;

namespace Collect.Web.AddFigures
{
	public class AddFigureController
	{
		private readonly IDocumentSession _documentSession;

		public AddFigureController(IDocumentSession documentSession)
		{
			_documentSession = documentSession;
		}

		public AddFigureViewModel AddFigure(AddFigureInputModel input)
		{
			return new AddFigureViewModel();
		}

		public AddFigureViewModel AddFigurePosted(AddFigurePostInputModel input)
		{
			//TODO: Remove. This is for testing
			if (input.FigureName == "fail")
			{
				return new AddFigureViewModel()
				{
					StatusMessage = "ONOUDINT",
					FigureName = "you're a failure"
				};
			}

			_documentSession.Store(new Figure()
				{
					Id = new Guid(),
					Name = input.FigureName,
					Year = input.YearReleased,
					Series = input.Series
				});

			return new AddFigureViewModel();
		}
	}
}