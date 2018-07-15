using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
	class GVASIntValue : IGVASValue
	{
		private uint mAddress;

		public uint Calc(uint address)
		{
			mAddress = address + 9;
			return address + 17;
		}

		public uint Address
		{
			get { return mAddress; }
		}
	}
}
