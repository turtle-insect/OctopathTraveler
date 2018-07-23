using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
	class Mission
	{
		private readonly GVASData mState;
		private readonly GVASData mClear;

		public Mission(GVASData state, GVASData clear)
		{
			mState = state;
			mClear = clear;
		}


		public uint State
		{
			get{ return SaveData.Instance().ReadNumber(mState.Address, mState.Size); }
			set{ Util.WriteNumber(mState.Address, mState.Size, value, 0, 2); }
		}

		public Boolean Clear
		{
			get { return SaveData.Instance().ReadNumber(mClear.Address, mClear.Size) == 1; }
			set { SaveData.Instance().WriteNumber(mClear.Address, mClear.Size, value == true ? 1U : 0); }
		}
	}
}
