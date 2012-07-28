using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collect.Web.Controllers
{
	public class HelloWorldController
	{
		public HelloViewModel SayHello(HelloInputModel input)
		{
			return new HelloViewModel
			{
				Message = "Hello Razor"
			};
		}
	}
}