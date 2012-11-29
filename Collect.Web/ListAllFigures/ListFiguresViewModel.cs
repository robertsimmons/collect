using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collect.Web.ListAllFigures
{
	public class ListFiguresViewModel
	{
		public ListFiguresViewModel()
		{
			PageHeader = "Browse Figures";
			Figures = new List<ListFigureViewModel>();
		}

		public string PageHeader { get; set; }
		public IList<ListFigureViewModel> Figures { get; set; }
	}

	public class ListFigureViewModel
	{
		public Guid Id { get; set; }
		public string FigureName { get; set; }
		public string Series { get; set; }
		public int YearReleased { get; set; }
		public string Tags { get; set; }
	}
}
