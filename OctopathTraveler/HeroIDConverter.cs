using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OctopathTraveler
{
	class HeroIDConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var infos = Info.Instance().CharaNames;
			for (uint i = 0; i < infos.Count; i++)
			{
				if (infos[(int)i].Value == (uint)value) return i;
			}
			return -1;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Info.Instance().CharaNames[(int)value].Value;
		}
	}
}
