using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
    class PartyGVAS : GVAS
    {
		public PartyGVAS(uint address)
		{
			address = AppendValue(address);
		}
	}
}
