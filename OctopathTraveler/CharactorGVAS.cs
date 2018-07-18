using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
	class CharactorGVAS : GVAS
	{
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

		protected override String KeyName(String key)
		{
			if (key == "Accessory")
			{
				String option = "1";
				if (mValues.ContainsKey("Accessory1")) option = "2";
				key += option;
			}
			return key;
		}
	}
}
