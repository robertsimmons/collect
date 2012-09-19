using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collect.Web.Controllers
{
	public class ListTransformersController
	{
		public ListTransformersViewModel ListTransformers(ListTransformersInputModel input)
		{
			return new ListTransformersViewModel();
		}
	}
}