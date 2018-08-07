using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace OctopathTraveler
{
	class DataContext
	{
		public ObservableCollection<Member> MainParty { get; set; } = new ObservableCollection<Member>();
		public ObservableCollection<Charactor> Charactors { get; set; } = new ObservableCollection<Charactor>();
		public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
		public ObservableCollection<MissionID> MissionIDs { get; set; } = new ObservableCollection<MissionID>();
		public ObservableCollection<CountryMission> Countris { get; set; } = new ObservableCollection<CountryMission>();
		public ObservableCollection<Place> Places { get; set; } = new ObservableCollection<Place>();
		public ObservableCollection<TameMonster> TameMonsters { get; set; } = new ObservableCollection<TameMonster>();

		public Info Info { get; private set; } = Info.Instance();

		private readonly uint mMoneyAddress;
		public DataContext()
		{
			SaveData save = SaveData.Instance();
			foreach (var address in save.FindAddress("CharacterID_", 0))
			{
				var chara = new Charactor(address);
				if (chara.ID < 0 || chara.ID > 8) continue;
				Charactors.Add(chara);
			}

			foreach (var address in save.FindAddress("ItemID_", 0))
			{
				Items.Add(new Item(address));
			}

			var gvas = new GVAS(null);
			gvas.AppendValue(save.FindAddress("MainMemberID_", 0)[0]);
			for(uint i = 0; i < 4; i++)
			{
				MainParty.Add(new Member(gvas.Key("MainMemberID_" + i.ToString()).Address));
			}

			gvas = new GVAS(null);
			gvas.AppendValue(save.FindAddress("SubMissionOrder", 0)[0]);
			for (uint i = 0; i < 200; i++)
			{
				MissionIDs.Add(new MissionID(gvas.Key("SubMissionOrder_" + i.ToString())));
			}

			var missionStates = save.FindAddress("MissionState_", 0);
			var clearIndex = save.FindAddress("ClearIndex_", 0);
			if(missionStates.Count == clearIndex.Count)
			{
				for (int i = 0; i < missionStates.Count; i++)
				{
					var stateGvas = new GVAS(null);
					stateGvas.AppendValue(missionStates[i]);
					var clearGvas = new GVAS(null);
					clearGvas.AppendValue(clearIndex[i]);

					var mission = new CountryMission() { Country = Info.Instance().Countris[i].Name };
					for(int j = 0; j < 100; j++)
					{
						mission.Missions.Add(new Mission(stateGvas.Key("MissionState_" + j.ToString()), clearGvas.Key("ClearIndex_" + j.ToString())));
					}
					Countris.Add(mission);
				}
			}

			gvas = new GVAS(null);
			gvas.AppendValue(save.FindAddress("VisitedMap", 0)[0]);
			uint id = 0;
			for (uint i = 0; i < 10; i++)
			{
				GVASData data = gvas.Key("VisitedMap_" + i.ToString());
				for (uint size = 0; size < data.Size; size++)
				{
					for (uint bit = 0; bit < 8; bit++)
					{
						var place = new Place(data.Address + size, bit);
						NameValueInfo info = Info.Instance().Search(Info.Instance().Places, id);
						if (info != null)
						{
							place.Name = info.Name;
						}
						Places.Add(place);
						id++;
					}
				}
			}

			gvas = new GVAS(null);
			uint tame = save.FindAddress("TameMonsterData", 0)[0];
			for (uint i = 0; i < 10; i++)
			{
				uint enemyAddress = save.FindAddress("EnemyID_", tame)[0];
				TameMonsters.Add(new TameMonster(enemyAddress));
				tame = enemyAddress + 1;
			}

			mMoneyAddress = save.FindAddress("Money", 0)[0] + 0x42;
		}

		public uint Money
		{
			get { return SaveData.Instance().ReadNumber(mMoneyAddress, 4); }
			set { Util.WriteNumber(mMoneyAddress, 4, value, 0, 9999999); }
		}
	}
}
