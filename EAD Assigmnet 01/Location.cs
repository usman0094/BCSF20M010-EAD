using System;
using System.Collections.Generic;

namespace EAD_Assignmnet01
{
	class Location
	{
		public float latitude { get; set; }
		public float longitude { get; set; }

		public Location(float latitude, float longitude)
		{
			this.latitude = latitude;
			this.longitude = longitude;
		}
		public void SetLocation(float lt, float lg)
		{
			latitude = lt;
			longitude = lg;
		}
		public double CalculateDistance(Location endLocation)
		{
			double latDistance = Math.Abs(latitude - endLocation.latitude);
			double longDistance = Math.Abs(longitude - endLocation.longitude);
			double distance = Math.Sqrt(latDistance * latDistance + longDistance * longDistance);
			return distance;
		}
	}

}
