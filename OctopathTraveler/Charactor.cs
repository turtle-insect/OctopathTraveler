using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace OctopathTraveler
{
	class Charactor : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private CharactorGVAS mGVAS;
		public Charactor(uint address)
		{
			mGVAS = new CharactorGVAS(address);
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("CharacterID"), 4); }
		}
		public uint Lv
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("Level"), 4); }
			set { Util.WriteNumber(mGVAS.Address("Level"), 4, value, 1, 99); }
		}

		public uint Exp
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("Exp"), 4); }
			set { Util.WriteNumber(mGVAS.Address("Exp"), 4, value, 0, 9999999); }
		}

		public uint RawHP
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("RawHP"), 4); }
			set { Util.WriteNumber(mGVAS.Address("RawHP"), 4, value, 0, 9999); }
		}

		public uint RawMP
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("RawMP"), 4); }
			set { Util.WriteNumber(mGVAS.Address("RawMP"), 4, value, 0, 9999); }
		}

		public uint FirstJob
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("FirstJobID"), 4); }
			set { SaveData.Instance().WriteNumber(mGVAS.Address("FirstJobID"), 4, value); }
		}

		public uint SecondJob
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("SecondJobID"), 4); }
			set { SaveData.Instance().WriteNumber(mGVAS.Address("SecondJobID"), 4, value); }
		}

		public uint JobPoint
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("JobPoint"), 4); }
			set { Util.WriteNumber(mGVAS.Address("JobPoint"), 4, value, 0, 9999); }
		}

		public uint HP
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("HP"), 4); }
			set { Util.WriteNumber(mGVAS.Address("HP"), 4, value, 0, 9999); }
		}

		public uint MP
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("MP"), 4); }
			set { Util.WriteNumber(mGVAS.Address("MP"), 4, value, 0, 9999); }
		}

		public uint BP
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("BP"), 4); }
			set { Util.WriteNumber(mGVAS.Address("BP"), 4, value, 0, 9999); }
		}

		public uint SP
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("SP"), 4); }
			set { Util.WriteNumber(mGVAS.Address("SP"), 4, value, 0, 9999); }
		}

		public uint ATK
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("ATK"), 4); }
			set { Util.WriteNumber(mGVAS.Address("ATK"), 4, value, 0, 9999); }
		}

		public uint DEF
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("DEF"), 4); }
			set { Util.WriteNumber(mGVAS.Address("DEF"), 4, value, 0, 9999); }
		}

		public uint MATK
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("MATK"), 4); }
			set { Util.WriteNumber(mGVAS.Address("MATK"), 4, value, 0, 9999); }
		}

		public uint MDEF
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("MDEF"), 4); }
			set { Util.WriteNumber(mGVAS.Address("MDEF"), 4, value, 0, 9999); }
		}

		public uint ACC
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("ACC"), 4); }
			set { Util.WriteNumber(mGVAS.Address("ACC"), 4, value, 0, 9999); }
		}

		public uint EVA
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("EVA"), 4); }
			set { Util.WriteNumber(mGVAS.Address("EVA"), 4, value, 0, 9999); }
		}

		public uint CON
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("CON"), 4); }
			set { Util.WriteNumber(mGVAS.Address("CON"), 4, value, 0, 9999); }
		}

		public uint AGI
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("AGI"), 4); }
			set { Util.WriteNumber(mGVAS.Address("AGI"), 4, value, 0, 9999); }
		}

		public uint Sword
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("Sword"), 4); }
			set
			{
				SaveData.Instance().WriteNumber(mGVAS.Address("Sword"), 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Sword)));
			}
		}

		public uint Lance
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("Lance"), 4); }
			set
			{
				SaveData.Instance().WriteNumber(mGVAS.Address("Lance"), 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lance)));
			}
		}

		public uint Dagger
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("Dagger"), 4); }
			set
			{
				SaveData.Instance().WriteNumber(mGVAS.Address("Dagger"), 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dagger)));
			}
		}

		public uint Axe
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("Axe"), 4); }
			set
			{
				SaveData.Instance().WriteNumber(mGVAS.Address("Axe"), 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Axe)));
			}
		}

		public uint Bow
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("Bow"), 4); }
			set
			{
				SaveData.Instance().WriteNumber(mGVAS.Address("Bow"), 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Bow)));
			}
		}

		public uint Rod
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("Rod"), 4); }
			set
			{
				SaveData.Instance().WriteNumber(mGVAS.Address("Rod"), 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Rod)));
			}
		}

		public uint Shield
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("Shield"), 4); }
			set
			{
				SaveData.Instance().WriteNumber(mGVAS.Address("Shield"), 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Shield)));
			}
		}

		public uint Head
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("Head"), 4); }
			set
			{
				SaveData.Instance().WriteNumber(mGVAS.Address("Head"), 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Head)));
			}
		}

		public uint Body
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("Body"), 4); }
			set
			{
				SaveData.Instance().WriteNumber(mGVAS.Address("Body"), 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Body)));
			}
		}

		public uint Accessory1
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("Accessory1"), 4); }
			set
			{
				SaveData.Instance().WriteNumber(mGVAS.Address("Accessory1"), 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Accessory1)));
			}
		}

		public uint Accessory2
		{
			get { return SaveData.Instance().ReadNumber(mGVAS.Address("Accessory2"), 4); }
			set
			{
				SaveData.Instance().WriteNumber(mGVAS.Address("Accessory2"), 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Accessory2)));
			}
		}
	}
}
