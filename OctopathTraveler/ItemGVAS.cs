using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
    class ItemGVAS
    {
		private Dictionary<String, IGVASValue> mValues = new Dictionary<string, IGVASValue>();

		public ItemGVAS(uint address)
		{
			for (int i = 0; i < 2; i++)
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
			address += length + 5;
			length = 1;
			for (; SaveData.Instance().ReadNumber(address + length, 1) != 0; length++) ;
			String type = SaveData.Instance().ReadText(address, length);
			address += length + 1;
			IGVASValue value = null;
			switch (type)
			{
				case "IntProperty":
					value = new GVASIntValue();
					break;

				case "ArrayProperty":
					value = new GVASArrayValue();
					break;
			}

			if (value != null)
			{
				address = value.Calc(address);
				mValues.Add(key, value);
			}

			return address;
		}
	}
}
