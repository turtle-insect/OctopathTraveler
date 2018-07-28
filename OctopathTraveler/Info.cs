using System;
using System.Collections.Generic;

namespace OctopathTraveler
{
	class Info
	{
		private static Info mThis;
		public List<NameValueInfo> Items { get; private set; } = new List<NameValueInfo>();
		public List<NameValueInfo> CharaNames { get; private set; } = new List<NameValueInfo>();
		public List<NameValueInfo> Jobs { get; private set; } = new List<NameValueInfo>();
		public List<NameValueInfo> Equipments { get; private set; } = new List<NameValueInfo>();
		public List<NameValueInfo> Countris { get; private set; } = new List<NameValueInfo>();
		public List<NameValueInfo> Places { get; private set; } = new List<NameValueInfo>();

		private Info() { }

		public static Info Instance()
		{
			if (mThis == null)
			{
				mThis = new Info();
				mThis.Init();
			}
			return mThis;
		}

		public NameValueInfo Search(List<NameValueInfo> list, uint id)
		{
			int min = 0;
			int max = list.Count;
			for (; min < max;)
			{
				int mid = (min + max) / 2;
				if (list[mid].Value == id) return list[mid];
				else if (list[mid].Value > id) max = mid;
				else min = mid + 1;
			}
			return null;
		}

		private void Init()
		{
			AppendList("info\\item.txt", Items);
			AppendList("info\\chara.txt", CharaNames);
			AppendList("info\\job.txt", Jobs);
			AppendList("info\\equipment.txt", Equipments);
			AppendList("info\\country.txt", Countris);
			AppendList("info\\place.txt", Places);
		}

		private void AppendList<Type>(String filename, List<Type> items)
			where Type : ILineAnalysis, new()
		{
			if (!System.IO.File.Exists(filename)) return;
			String[] lines = System.IO.File.ReadAllLines(filename);
			foreach (String line in lines)
			{
				if (line.Length < 3) continue;
				if (line[0] == '#') continue;
				String[] values = line.Split('\t');
				if (values.Length < 2) continue;
				if (String.IsNullOrEmpty(values[0])) continue;
				if (String.IsNullOrEmpty(values[1])) continue;

				Type type = new Type();
				if(type.Line(values))
				{
					items.Add(type);
				}
			}
		}
	}
}
