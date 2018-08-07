using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace OctopathTraveler
{
	class TameMonster : INotifyPropertyChanged
	{
		private GVAS mGVAS;
		public event PropertyChangedEventHandler PropertyChanged;

		public TameMonster(uint address)
		{
			mGVAS = new GVAS(null);
			for (int i = 0; i < 3; i++)
			{
				address = mGVAS.AppendValue(address);
			}
		}

		public uint ID
		{
			get
			{
				GVASData data = mGVAS.Key("EnemyID");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}

			set
			{
				GVASData data = mGVAS.Key("EnemyID");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Count
		{
			get
			{
				GVASData data = mGVAS.Key("Count");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}

			set
			{
				GVASData data = mGVAS.Key("Count");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
			}
		}

		public bool Used
		{
			get
			{
				GVASData data = mGVAS.Key("Used");
				return SaveData.Instance().ReadNumber(data.Address, data.Size) == 5U;
			}

			set
			{
				GVASData data = mGVAS.Key("Used");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value ? 5U : 0);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Used)));
			}
		}
	}
}
