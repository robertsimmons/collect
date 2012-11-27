using Collect.Web.Domain.Entities;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collect.Web.ViewFigures
{
	public class ViewFigureController
	{
		private readonly IDocumentSession _documentSession;

		public ViewFigureController(IDocumentSession documentSession)
		{
			_documentSession = documentSession;
		}

		public ViewFigureViewModel ViewFigure_FigureId(ViewFigureInputModel input)
		{
			var figure = _documentSession.Load<Figure>(input.FigureId);

			return new ViewFigureViewModel()
				{
					FigureId = input.FigureId,
					FigureName = figure.Name
				};
		}
	}
}