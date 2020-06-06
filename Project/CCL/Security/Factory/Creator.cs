using System;
using System.Collections.Generic;
using System.Text;
using CCL.Security.Identity;

namespace CCL.Security.Factory
{
	abstract class Creator
	{
		public abstract User FactoryMethod();
	}
}
