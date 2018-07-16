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

		private ItemGVAS mGVAS;
		public Item(uint address)
		{
			mGVAS = new ItemGVAS(address);
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("ItemID"), 4); }
			set
			{
				SaveData.Instance().WriteNumber(mGVAS.Address("ItemID"), 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Count
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("Num"), 4); }
			set
			{
				Util.WriteNumber(mGVAS.Address("Num"), 4, value, 0, 99);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
			}
		}
	}
}
