using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core.Behaviors;
using Raven.Client;

namespace Collect.Web.App_Start
{
	public class RavenBehavior : IActionBehavior
	{
		private readonly IDocumentSession _documentSession;
		public IActionBehavior InsideBehavior { get; set; }

		public RavenBehavior(IDocumentSession documentSession)
		{
			_documentSession = documentSession;
		}

		public void Invoke()
		{
			InsideBehavior.Invoke();
			_documentSession.SaveChanges();
		}

		public void InvokePartial()
		{
			//Nothing to do here because we are already inside Invoke()
			InsideBehavior.InvokePartial();
		}
	}
}