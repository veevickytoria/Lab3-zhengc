
using System;

namespace Expedia
{
	public class Flight : Booking
	{
		private DateTime dateThatFlightLeaves;
		private DateTime dateThatFlightReturns;
		
		public int Miles
		{
			get; private set;	
		}
		
		#region Booking implementation
		public double getBasePrice ()
		{
			var lengthOfSpread = (dateThatFlightReturns - dateThatFlightLeaves).Days;
			
			return 200 + lengthOfSpread*20;
		}
		#endregion
		
		public Flight (DateTime startDate, DateTime endDate, int someMiles)
		{
			if(endDate < startDate)
				throw new InvalidOperationException("End date cannot be before start date!");
			
			if(someMiles < 0)
				throw new ArgumentOutOfRangeException("Miles must be positive!");
			
			dateThatFlightLeaves = startDate;
			dateThatFlightReturns = endDate;
			Miles = someMiles;
		}
		
		public override bool Equals(object obj) {
			if(obj is Flight) {
				return Equals(obj as Flight);
			}
			
			return base.Equals(obj);
		}
		
		private bool Equals(Flight obj) {
			bool l = obj.dateThatFlightLeaves.Equals(this.dateThatFlightLeaves);
			bool r = obj.dateThatFlightReturns.Equals(this.dateThatFlightReturns);
			bool m = obj.Miles.Equals(this.Miles);
			return l && r && m;
		}
	}
}
