using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
	class CharactorGVAS
	{
		private Dictionary<String, IGVASValue> mValues = new Dictionary<string, IGVASValue>();

		public CharactorGVAS(uint address)
		{
			for(int i = 0; i < 9; i++)
			{
				address = AppendValue(address);
			}

			address = SaveData.Instance().FindAddress("Sword_", address)[0];
			for (int i = 0; i < 11; i++)
			{
				address = AppendValue(address);
			}

			address = SaveData.Instance().FindAddress("HP_", address)[0];
			for (int i = 0; i < 12; i++)
			{
				address = AppendValue(address);
			}
		}

		public uint Address(String key)
		{
			return mValues[key].Address;
		}

		private uint AppendValue(uint address)
		{
			uint length = 1;
			for (; SaveData.Instance().ReadNumber(address + length, 1) != 0; length++) ;
			String key = SaveData.Instance().ReadText(address, length);
			key = key.Substring(0, key.IndexOf("_"));
			if(key == "Accessory")
			{
				String option = "1";
				if (mValues.ContainsKey("Accessory1")) option = "2";
				key += option;
			}
				address += length + 5;
			length = 1;
			for (; SaveData.Instance().ReadNumber(address + length, 1) != 0; length++) ;
			String type = SaveData.Instance().ReadText(address, length);
			address += length + 1;
			IGVASValue value = null;
			switch(type)
			{
				case "IntProperty":
					value = new GVASIntValue();
					break;

				case "ArrayProperty":
					value = new GVASArrayValue();
					break;
			}

			if(value != null)
			{
				address = value.Calc(address);
				mValues.Add(key, value);
			}

			return address;
		}
	}
}
