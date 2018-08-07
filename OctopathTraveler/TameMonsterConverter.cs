using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OctopathTraveler
{
	class TameMonsterConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			for(uint i = 0; i < Info.Instance().TameMonsters.Count; i++)
			{
				if (Info.Instance().TameMonsters[(int)i].Value == (uint)value) return i;
			}

			return -1;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			for (uint i = 0; i < Info.Instance().TameMonsters.Count; i++)
			{
				if (Info.Instance().TameMonsters[(int)i].Value == (int)value) return Info.Instance().TameMonsters[(int)i].Value;
			}

			return 0xFFFFFFFF;
		}
	}
}
