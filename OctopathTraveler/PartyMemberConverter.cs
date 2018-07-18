using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OctopathTraveler
{
	class PartyMemberConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			uint tmp = (uint)value;
			if (tmp != uint.MaxValue) tmp++;
			for (int i = 0; i < Info.Instance().CharaNames.Count; i++)
			{
				if (Info.Instance().CharaNames[i].Value == tmp) return i;
			}

			return -1;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			uint tmp = Info.Instance().CharaNames[(int)value].Value;
			if (tmp != uint.MaxValue) tmp--;
			return tmp;
		}
	}
}
