using Collect.Web.AddFigures;
using NUnit.Framework;
using Raven.Client;
using SpecsFor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Collect.Web.Domain.Entities;
using Should;

namespace Collect.Web.Tests.AddFigures
{
	public class AddFigurePostedSpecs : SpecsFor<AddFigureController>
	{
		private AddFigureViewModel _input = new AddFigureViewModel()
		{
			FigureName = "heyo",
			Series = "mah series",
			Year = 1992,
			Tags = "hey,you,guys"
		};

		private AddFigureViewModel _result;

		protected override void When()
		{
			_result = SUT.AddFigurePosted(_input);
		}

		[Test]
		public void then_it_should_save()
		{
			GetMockFor<IDocumentSession>()
				.Verify(x => x.Store(It.Is<Figure>(fig => fig.Name == _input.FigureName &&
														fig.Series == _input.Series &&
														fig.Year == _input.Year &&
														fig.Tags[0] == "hey" &&
														fig.Tags[1] == "you" &&
														fig.Tags[2] == "guys")), Times.Once());
		}

		[Test]
		public void then_it_should_have_success_message()
		{
			_result.StatusMessage.ShouldContain("added");
		}

	}
}
