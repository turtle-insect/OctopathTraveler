using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
    class CountryMission
    {
		public String Country { get; set; }
		public List<Mission> Missions { get; set; } = new List<Mission>();
	}
}
