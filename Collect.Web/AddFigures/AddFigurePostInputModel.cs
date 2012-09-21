using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collect.Web.AddFigures
{
	public class AddFigurePostInputModel
	{
		public string FigureName { get; set; }
		public string Series { get; set; }
		public int YearReleased { get; set; }
	}
}