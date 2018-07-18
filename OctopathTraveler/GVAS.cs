using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
    class GVAS
    {
		private Dictionary<String, uint> mValues = new Dictionary<string, uint>();
		private IGVASRenameKey mRename;

		public GVAS(IGVASRenameKey rename)
		{
			mRename = rename;
		}

		public uint Address(String key)
		{
			return mValues[key];
		}

		public bool HasKey(String key)
		{
			return mValues.ContainsKey(key);
		}

		public uint AppendValue(uint address)
		{
			uint length = 1;
			for (; SaveData.Instance().ReadNumber(address + length, 1) != 0; length++) ;
			String key = SaveData.Instance().ReadText(address, length);
			key = key.Substring(0, key.IndexOf("_"));
			if(mRename != null)
			{
				key = mRename.Rename(key);
			}
			address += length + 5;
			length = 1;
			for (; SaveData.Instance().ReadNumber(address + length, 1) != 0; length++) ;
			String type = SaveData.Instance().ReadText(address, length);
			address += length + 1;
			switch (type)
			{
				case "IntProperty":
					mValues.Add(key, address + 9);
					address += 17;
					break;

				case "ArrayProperty":
					address += 25;
					uint count = SaveData.Instance().ReadNumber(address, 4);
					address += 4;
					for (uint i = 0; i < count; i++)
					{
						mValues.Add(key + "_" + i.ToString(), address);
						address += 4;
					}
					address += 4;
					break;
			}
			return address;
		}
	}
}
