﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;

namespace Collect.Web.ListAllFigures
{
	public class ListFiguresController
	{
		public ListFiguresViewModel ListFigures(ListFiguresInputModel input)
		{
			return new ListFiguresViewModel();
		}
	}
}