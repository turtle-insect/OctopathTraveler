using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
	class GVASArrayValue : IGVASValue
	{
		//private uint mSize;
		//private String mType;
		private uint mAddress;

		public uint Calc(uint address)
		{
			for (address += 12; SaveData.Instance().ReadNumber(address, 1) != 0; address++) ;
			address += 2;
			mAddress = address;
			return address + 8;
		}

		public uint Address
		{
			get { return mAddress; }
		}
	}
}
