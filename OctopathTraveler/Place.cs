using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
	class Place
	{
		private readonly uint mAddress;
		private readonly uint mBit;

		public Place(uint address, uint bit)
		{
			mAddress = address;
			mBit = bit;
		}

		public String Name { get; set; }

		public bool Visit
		{
			get { return SaveData.Instance().ReadBit(mAddress, mBit); }
			set { SaveData.Instance().WriteBit(mAddress, mBit, value); }
		}
	}
}
