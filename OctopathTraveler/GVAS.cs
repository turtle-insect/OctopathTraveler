using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
    class GVAS
    {
		private Dictionary<String, GVASData> mValues = new Dictionary<string, GVASData>();
		private IGVASRenameKey mRename;

		public GVAS(IGVASRenameKey rename)
		{
			mRename = rename;
		}

		public GVASData Key(String key)
		{
			return mValues[key];
		}

		public bool HasKey(String key)
		{
			return mValues.ContainsKey(key);
		}

		public uint AppendValue(uint address)
		{
			// length
			address -= 4;
			uint length = SaveData.Instance().ReadNumber(address, 4);
			// key
			address += 4;
			String key = SaveData.Instance().ReadText(address, length);
			if (key.IndexOf("_") > 0)
			{
				key = key.Substring(0, key.IndexOf("_"));
			}
			if(mRename != null)
			{
				key = mRename.Rename(key);
			}
			address += length;
			length = SaveData.Instance().ReadNumber(address, 4);
			address += 4;
			String type = SaveData.Instance().ReadText(address, length);
			address += length;
			switch (type)
			{
				case "IntProperty":
					mValues.Add(key, new GVASData() { Address = address + 9, Size = 4 });
					address += 17;
					break;

				case "BoolProperty":
					mValues.Add(key, new GVASData() { Address = address + 10, Size = 1 });
					address += 17;
					break;

				case "ArrayProperty":
					address += 8;
					length = SaveData.Instance().ReadNumber(address, 4);
					address += 4;
					type = SaveData.Instance().ReadText(address, length);
					address += length + 1;
					uint count = SaveData.Instance().ReadNumber(address, 4);
					address += 4;

					uint size = 4;
					switch(type)
					{
						case "BoolProperty":
						case "ByteProperty":
							size = 1;
							break;
					}
					for (uint i = 0; i < count; i++)
					{
						mValues.Add(key + "_" + i.ToString(), new GVASData() { Address = address, Size = size });
						address += size;
					}
					address += size;
					break;

				default:
					address += 4;
					address += AppendValue(address);
					break;
			}
			return address;
		}
	}
}
