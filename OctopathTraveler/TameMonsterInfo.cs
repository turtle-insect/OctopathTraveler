using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
	class TameMonsterInfo : NameValueInfo
	{
		public List<String> Types { get; private set; }
		public uint Strengh { get; private set; }
		public List<String> Skills { get; private set; }
		public String Special { get; private set; }

		public override bool Line(String[] oneLine)
		{
			base.Line(oneLine);
			Types = oneLine[2].Split('/').ToList();
			uint value;
			if (UInt32.TryParse(oneLine[3], out value)) Strengh = value;
			Skills = oneLine[4].Split('/').ToList();
			Special = oneLine[5];
			return true;
		}
	}
}
