using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecsFor;
using Collect.Web.App_Start;
using NUnit.Framework;
using Raven.Client;
using Moq;
using FubuMVC.Core.Behaviors;

namespace Collect.Web.Tests.App_Start
{
	public class RavenBehaviorSpecs : SpecsFor<RavenBehavior>
	{

		protected override void Given()
		{
			base.Given();
			SUT.InsideBehavior = new DummyInsideBehavior();
		}

		protected override void When()
		{
			SUT.Invoke();
		}

		[Test]
		public void then_it_should_save_any_changes()
		{
			GetMockFor<IDocumentSession>()
				.Verify(ds => ds.SaveChanges());
		}

		#region Dummy test bs.
		//HAH, I'm using a region to hide crap code.
		internal class DummyInsideBehavior : IActionBehavior
		{
			public void Invoke()
			{
				//no-op
			}

			public void InvokePartial()
			{
				//no-op
			}
		}
		#endregion
	}
}
