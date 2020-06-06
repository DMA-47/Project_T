using System.Collections.Generic;
using System.Text;
using CCL.Security.Identity;

namespace CCL.Security.Factory
{
	class CreatorStorageManager : Creator
	{

		public override User FactoryMethod()
		{
			return new StorageManager();
		}
	}
}
