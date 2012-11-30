using Collect.Web.Domain.Entities;
using Collect.Web.ListAllFigures;
using NUnit.Framework;
using Raven.Client;
using SpecsFor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Should;

namespace Collect.Web.Tests.ListAllFigures
{
	public class ListFigureSpecs : SpecsFor<ListFiguresController>
	{
		private ListFiguresViewModel _result;
		private ListFiguresInputModel _input = new ListFiguresInputModel();

		protected override void Given()
		{
			//TODO: these need to be cleaned out.
			var session = SetUp.DocumentStore.OpenSession();
			session.Store(new Figure()
			{
				Name = "a",
				Tags = new List<string>(){ "lets", "get", "a", "soda" }
			});
			session.Store(new Figure()
			{
				Name = "c"
			});
			session.Store(new Figure()
			{
				Name = "v"
			});
			session.Store(new Figure()
			{
				Name = "b"
			});
			session.SaveChanges();
		}

		protected override void When()
		{
			_result = SUT.ListFigures(_input);
		}

		protected override void ConfigureContainer(StructureMap.IContainer container)
		{
			base.ConfigureContainer(container);

			container.Configure(x => x.For<IDocumentSession>().Use(() => SetUp.DocumentStore.OpenSession()));
		}

		[Test]
		public void then_it_should_order_by_name()
		{
			_result.Figures[0].FigureName.ShouldEqual("a");
			_result.Figures[1].FigureName.ShouldEqual("b");
			_result.Figures[2].FigureName.ShouldEqual("c");
			_result.Figures[3].FigureName.ShouldEqual("v");
		}

		[Test]
		public void then_it_should_flatten_tags()
		{
			_result.Figures[0].Tags.ShouldEqual("lets, get, a, soda");
		}
	}
}
