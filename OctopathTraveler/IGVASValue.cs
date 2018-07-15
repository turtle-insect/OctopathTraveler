using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopathTraveler
{
	interface IGVASValue
	{
		uint Calc(uint address);
		uint Address { get; }
	}
}
