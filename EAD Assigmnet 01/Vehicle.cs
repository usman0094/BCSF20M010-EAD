using System;
using System.Collections.Generic;

namespace EAD_Assignmnet01
{
	class Vehicle
	{
		public string type { get; set; }
		public string model { get; set; }
		public string licensePlate { get; set; }

		public Vehicle(string type, string model, string licensePlate)
		{
			this.type = type;
			this.model = model;
			this.licensePlate = licensePlate;
		}

	}
}

