using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
	class Item : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private GVAS mGVAS;
		public Item(uint address)
		{
			mGVAS = new GVAS(null);

			for (int i = 0; i < 2; i++)
			{
				address = mGVAS.AppendValue(address);
			}
		}

		public uint ID
		{
			get
			{
				GVASData data = mGVAS.Key("ItemID");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("ItemID");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Count
		{
			get
			{
				GVASData data = mGVAS.Key("Num");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("Num");
				Util.WriteNumber(data.Address, data.Size, value, 0, 99);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
			}
		}
	}
}
