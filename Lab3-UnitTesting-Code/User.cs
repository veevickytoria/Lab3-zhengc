using System;
using System.Collections.Generic;
using System.Collections;

namespace Expedia
{
	public class User
	{
		public User(String aName)
		{
			Name = aName;
			Bookings = new List<Booking>();
		}
		
		public String Name
		{
			get; private set;
		}
		
		public Int32 FrequentFlierMiles
		{
			get 
			{
				var result = 0;
				foreach(var booking in Bookings)
				{
					if(booking.GetType() == typeof(Flight))
					{
						result += ((Flight)booking).Miles;
					}
				}
				return result;
			}
		}
		
		public List<Booking> Bookings
		{
			get; private set;
		}
		
		public void book(params Booking[] bookings)
		{
			foreach(var booking in bookings)
			{
				Bookings.Add(booking);
			}
		}
	}
}
