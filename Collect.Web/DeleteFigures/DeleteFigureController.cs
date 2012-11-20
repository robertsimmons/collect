using Collect.Web.Domain.Entities;
using FubuMVC.Core;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collect.Web.DeleteFigures
{
	public class DeleteFigureController
	{
		private readonly IDocumentSession _documentSession;

		public DeleteFigureController(IDocumentSession documentSession)
		{
			_documentSession = documentSession;
		}

		[JsonEndpoint]
		public DeleteOutputModel Delete(DeleteInputModel input)
		{
			try
			{
				var figureToDelete = _documentSession.Load<Figure>(input.IdToDelete);

				_documentSession.Delete(figureToDelete);
			}
			catch(Exception ex)
			{
				return new DeleteOutputModel()
				{
					StatusMessage = "Well crap! " + ex.Message,
					Success = false
				};
			}

			return new DeleteOutputModel()
			{
				StatusMessage = "It's gone!",
				Success = true
			};
		}
	}
}