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
			Figures = new List<ListFigureViewModel>();
		}

		public IList<ListFigureViewModel> Figures { get; set; }
	}

	public class ListFigureViewModel
	{
		public Guid Id { get; set; }
		public string FigureName { get; set; }
		public string Series { get; set; }
		public int YearReleased { get; set; }
	}
}
