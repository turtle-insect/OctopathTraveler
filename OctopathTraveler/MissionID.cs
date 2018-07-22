using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
	class MissionID
	{
		private readonly GVASData mData;
		public MissionID(GVASData data)
		{
			mData = data;
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mData.Address, mData.Size); }
			set { SaveData.Instance().WriteNumber(mData.Address, mData.Size, value); }
		}
	}
}
