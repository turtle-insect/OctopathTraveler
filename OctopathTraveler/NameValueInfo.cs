using System;

namespace OctopathTraveler
{
	class NameValueInfo : ILineAnalysis
	{
		public uint Value { get; private set; }
		public String Name { get; private set; }

		public virtual bool Line(String[] oneLine)
		{
			if (oneLine[0].Length > 1 && oneLine[0][1] == 'x') Value = Convert.ToUInt32(oneLine[0], 16);
			else Value = Convert.ToUInt32(oneLine[0]);
			Name = oneLine[1];
			return true;
		}
	}
}
