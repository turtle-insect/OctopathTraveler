using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
	class ContryMission
	{
		private readonly GVASData mState;
		private readonly GVASData mClear;

		public ContryMission(String name, GVASData state, GVASData clear)
		{
			Country = name;
			mState = state;
			mClear = clear;
		}

		public String Country { get; private set; }

		public uint State
		{
			get{ return SaveData.Instance().ReadNumber(mState.Address, mState.Size); }
			set{ Util.WriteNumber(mState.Address, mState.Size, value, 0, 2); }
		}

		public Boolean Clear
		{
			get { return SaveData.Instance().ReadNumber(mState.Address, mState.Size) == 1; }
			set { SaveData.Instance().WriteNumber(mState.Address, mState.Size, value == true ? 1U : 0); }
		}
	}
}
