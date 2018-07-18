using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
    class ItemGVAS : GVAS
    {
		public ItemGVAS(uint address)
		{
			for (int i = 0; i < 2; i++)
			{
				address = AppendValue(address);
			}
		}
	}
}
