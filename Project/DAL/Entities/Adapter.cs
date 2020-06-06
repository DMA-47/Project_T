using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.Entities
{
	class Adapter : Product
	{
        private Storage st = new Storage();

        public override void metod1()
        {
            st.metod2();
        }
    }
}
