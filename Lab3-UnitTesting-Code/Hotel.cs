
using System;

namespace Expedia
{
	public class Hotel : Booking
	{
		private int numberOfNightsToRent;
		
		#region Booking implementation
		public double getBasePrice ()
		{
			return 45 * numberOfNightsToRent;
		}
		#endregion
		
		public Hotel (int nightsToRent)
		{
			if(nightsToRent <= 0)
				throw new ArgumentOutOfRangeException("Nights to rent must be greater than zero!");
			
			numberOfNightsToRent = nightsToRent;
		}
		
		public override bool Equals(object obj) {
			if(obj is Hotel) {
				return Equals(obj as Hotel);
			}
			
			return base.Equals(obj);
		}
		
		private bool Equals(Hotel obj) {
			return obj.numberOfNightsToRent.Equals(this.numberOfNightsToRent);
		}
	}
}
