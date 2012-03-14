
using System;

namespace Expedia
{
	public class Car : Booking
	{
		private int numberOfDaysToRent;
		
		#region Booking implementation
		public double getBasePrice ()
		{	
			double result = numberOfDaysToRent * 10;
			
			if(numberOfDaysToRent > 5)
			{	
				result *= 0.8;
			}
			
			return result;
		}
		#endregion
		
		public Car (int daysToRent)
		{
			if(daysToRent <= 0)
				throw new ArgumentOutOfRangeException("Days to Rent must be greater than zero!");
			
			numberOfDaysToRent = daysToRent;
		}
	}
}
