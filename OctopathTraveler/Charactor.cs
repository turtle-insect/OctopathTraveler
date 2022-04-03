using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace OctopathTraveler
{
	class Charactor : INotifyPropertyChanged, IGVASRenameKey
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private GVAS mGVAS;
		public Charactor(uint address)
		{
			mGVAS = new GVAS(this);

			for (int i = 0; i < 9; i++)
			{
				address = mGVAS.AppendValue(address);
			}

			address = SaveData.Instance().FindAddress("Sword_", address)[0];
			for (int i = 0; i < 11; i++)
			{
				address = mGVAS.AppendValue(address);
			}

			address = SaveData.Instance().FindAddress("HP_", address)[0];
			for (int i = 0; i < 12; i++)
			{
				address = mGVAS.AppendValue(address);
			}
		}

		public uint ID
		{
			get
			{
				GVASData data = mGVAS.Key("CharacterID");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
		}

		public uint Lv
		{
			get
			{
				GVASData data = mGVAS.Key("Level");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("Level");
				Util.WriteNumber(data.Address, data.Size, value, 1, 99);
			}
		}

		public uint Exp
		{
			get
			{
				GVASData data = mGVAS.Key("Exp");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("Exp");
				Util.WriteNumber(data.Address, data.Size, value, 0, 5505414);
			}
		}

		public uint RawHP
		{
			get
			{
				GVASData data = mGVAS.Key("RawHP");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("RawHP");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
			}
		}

		public uint RawMP
		{
			get
			{
				GVASData data = mGVAS.Key("RawMP");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("RawMP");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
			}
		}

		public uint FirstJob
		{
			get
			{
				GVASData data = mGVAS.Key("FirstJobID");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("FirstJobID");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
			}
		}

		public uint SecondJob
		{
			get
			{
				GVASData data = mGVAS.Key("SecondJobID");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("SecondJobID");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
			}
		}

		public uint JobPoint
		{
			get
			{
				GVASData data = mGVAS.Key("JobPoint");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("JobPoint");
				Util.WriteNumber(data.Address, data.Size, value, 0, 999999);
			}
		}

		public uint HP
		{
			get
			{
				GVASData data = mGVAS.Key("HP");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("HP");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
			}
		}

		public uint MP
		{
			get
			{
				GVASData data = mGVAS.Key("MP");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("MP");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
			}
		}

		public uint BP
		{
			get
			{
				GVASData data = mGVAS.Key("BP");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("BP");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
			}
		}

		public uint SP
		{
			get
			{
				GVASData data = mGVAS.Key("SP");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("SP");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
			}
		}

		public uint ATK
		{
			get
			{
				GVASData data = mGVAS.Key("ATK");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("ATK");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
			}
		}

		public uint DEF
		{
			get
			{
				GVASData data = mGVAS.Key("DEF");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("DEF");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
			}
		}

		public uint MATK
		{
			get
			{
				GVASData data = mGVAS.Key("MATK");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("MATK");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
			}
		}

		public uint MDEF
		{
			get
			{
				GVASData data = mGVAS.Key("MDEF");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("MDEF");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
			}
		}

		public uint ACC
		{
			get
			{
				GVASData data = mGVAS.Key("ACC");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("ACC");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
			}
		}

		public uint EVA
		{
			get
			{
				GVASData data = mGVAS.Key("EVA");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("EVA");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
			}
		}

		public uint CON
		{
			get
			{
				GVASData data = mGVAS.Key("CON");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("CON");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
			}
		}

		public uint AGI
		{
			get
			{
				GVASData data = mGVAS.Key("AGI");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("AGI");
				Util.WriteNumber(data.Address, data.Size, value, 0, 9999);
			}
		}

		public uint Sword
		{
			get
			{
				GVASData data = mGVAS.Key("Sword");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("Sword");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Sword)));
			}
		}

		public uint Lance
		{
			get
			{
				GVASData data = mGVAS.Key("Lance");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("Lance");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lance)));
			}
		}

		public uint Dagger
		{
			get
			{
				GVASData data = mGVAS.Key("Dagger");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("Dagger");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dagger)));
			}
		}

		public uint Axe
		{
			get
			{
				GVASData data = mGVAS.Key("Axe");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("Axe");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Axe)));
			}
		}

		public uint Bow
		{
			get
			{
				GVASData data = mGVAS.Key("Bow");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("Bow");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Bow)));
			}
		}

		public uint Rod
		{
			get
			{
				GVASData data = mGVAS.Key("Rod");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("Rod");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Rod)));
			}
		}

		public uint Shield
		{
			get
			{
				GVASData data = mGVAS.Key("Shield");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("Shield");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Shield)));
			}
		}

		public uint Head
		{
			get
			{
				GVASData data = mGVAS.Key("Head");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("Head");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Head)));
			}
		}

		public uint Body
		{
			get
			{
				GVASData data = mGVAS.Key("Body");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("Body");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Body)));
			}
		}

		public uint Accessory1
		{
			get
			{
				GVASData data = mGVAS.Key("Accessory1");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("Accessory1");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Accessory1)));
			}
		}

		public uint Accessory2
		{
			get
			{
				GVASData data = mGVAS.Key("Accessory2");
				return SaveData.Instance().ReadNumber(data.Address, data.Size);
			}
			set
			{
				GVASData data = mGVAS.Key("Accessory2");
				SaveData.Instance().WriteNumber(data.Address, data.Size, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Accessory2)));
			}
		}

		public string Rename(string key)
		{
			if (key == "Accessory")
			{
				String option = "1";
				if (mGVAS.HasKey("Accessory1")) option = "2";
				key += option;
			}
			return key;
		}
	}
}
