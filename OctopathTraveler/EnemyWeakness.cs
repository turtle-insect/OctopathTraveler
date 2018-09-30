using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace OctopathTraveler
{
	class EnemyWeakness : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly uint mWeaponAddress;
		private readonly uint mMagicAddress;
		public EnemyWeakness(uint address)
		{
			var gvas = new GVAS(null);
			gvas.AppendValue(SaveData.Instance().FindAddress("WeaknessOpen_", address)[0]);
			mWeaponAddress = gvas.Key("WeaknessOpen").Address;
			mMagicAddress = mWeaponAddress + 1;
		}

		public bool Sword
		{
			get { return SaveData.Instance().ReadBit(mWeaponAddress, 0); }
			set
			{
				SaveData.Instance().WriteBit(mWeaponAddress, 0, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Sword)));
			}
		}

		public bool Lance
		{
			get { return SaveData.Instance().ReadBit(mWeaponAddress, 1); }
			set
			{
				SaveData.Instance().WriteBit(mWeaponAddress, 1, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lance)));
			}
		}

		public bool Dagger
		{
			get { return SaveData.Instance().ReadBit(mWeaponAddress, 2); }
			set
			{
				SaveData.Instance().WriteBit(mWeaponAddress, 2, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dagger)));
			}
		}

		public bool Axe
		{
			get { return SaveData.Instance().ReadBit(mWeaponAddress, 3); }
			set
			{
				SaveData.Instance().WriteBit(mWeaponAddress, 3, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Axe)));
			}
		}

		public bool Bow
		{
			get { return SaveData.Instance().ReadBit(mWeaponAddress, 4); }
			set
			{
				SaveData.Instance().WriteBit(mWeaponAddress, 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Bow)));
			}
		}

		public bool Rod
		{
			get { return SaveData.Instance().ReadBit(mWeaponAddress, 5); }
			set
			{
				SaveData.Instance().WriteBit(mWeaponAddress, 5, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Rod)));
			}
		}

		public bool Fire
		{
			get { return SaveData.Instance().ReadBit(mMagicAddress, 0); }
			set
			{
				SaveData.Instance().WriteBit(mMagicAddress, 0, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Fire)));
			}
		}

		public bool Ice
		{
			get { return SaveData.Instance().ReadBit(mMagicAddress, 1); }
			set
			{
				SaveData.Instance().WriteBit(mMagicAddress, 1, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ice)));
			}
		}

		public bool Thunder
		{
			get { return SaveData.Instance().ReadBit(mMagicAddress, 2); }
			set
			{
				SaveData.Instance().WriteBit(mMagicAddress, 2, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Thunder)));
			}
		}

		public bool Wind
		{
			get { return SaveData.Instance().ReadBit(mMagicAddress, 3); }
			set
			{
				SaveData.Instance().WriteBit(mMagicAddress, 3, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Wind)));
			}
		}

		public bool Light
		{
			get { return SaveData.Instance().ReadBit(mMagicAddress, 4); }
			set
			{
				SaveData.Instance().WriteBit(mMagicAddress, 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Light)));
			}
		}

		public bool Dark
		{
			get { return SaveData.Instance().ReadBit(mMagicAddress, 5); }
			set
			{
				SaveData.Instance().WriteBit(mMagicAddress, 5, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dark)));
			}
		}
	}
}
