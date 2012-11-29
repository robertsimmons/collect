using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collect.Web.Domain.Entities
{
	public class Figure
	{
		public Figure()
		{
			Id = new Guid();
			Tags = new List<string>();
		}

		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Year { get; set; }
		public string Series { get; set; }
		public IList<string> Tags { get; set; }
	}
}