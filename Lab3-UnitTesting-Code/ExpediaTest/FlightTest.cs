using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{

		[Test()]
		public void TestThatFlightInitializes()
		{
			var target = new Flight(DateTime.Now, DateTime.Now.AddDays(10), 1);
			Assert.IsNotNull(target);
		}
		
		[Test()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatHotelThrowsOnBadMiles()
		{
			new Flight(DateTime.Now, DateTime.Now.AddDays(10), -10);
		}
		
		[Test()]
		[ExpectedException(typeof(InvalidOperationException))]
		public void TestThatHotelThrowsOnBadDates()
		{
			new Flight(DateTime.Now.AddDays(10), DateTime.Now, -10);
		}
		
		[Test()]
		public void TestThatFlightHasCorrectBasePriceForOneDay()
		{
			var target = new Flight(DateTime.Now, DateTime.Now.AddDays(1), 1);
			Assert.AreEqual(220, target.getBasePrice());
		}
		
		[Test()]
		public void TestThatFlightHasCorrectBasePriceForTwoDays()
		{
			var target = new Flight(DateTime.Now, DateTime.Now.AddDays(2), 5);
			Assert.AreEqual(240, target.getBasePrice());
		}
		
		[Test()]
		public void TestThatFlightHasCorrectBasePriceForTenDays()
		{
			var target = new Flight(DateTime.Now, DateTime.Now.AddDays(10), 10);
			Assert.AreEqual((200+10*20), target.getBasePrice());
		}
		
		[Test()]
		public void TestFlightsEquality()
		{
			DateTime sDate = DateTime.Now;
			DateTime rDate = DateTime.Now.AddDays(10);
			Flight target1 = new Flight(sDate, rDate, 10);
			Flight target2 = new Flight(sDate, rDate, 10);
			Assert.IsTrue(target1.Equals(target2));
		}
		
		[Test()]
		public void TestFlightsInequalityDueToStartDate()
		{
			DateTime rDate = DateTime.Now.AddDays(10);
			var target1 = new Flight(DateTime.Now, rDate, 10);
			var target2 = new Flight(DateTime.Now, rDate, 10);
			Assert.IsFalse(target1.Equals(target2));
		}
		
		[Test()]
		public void TestFlightsInequalityDueToEndDate()
		{
			DateTime sDate = DateTime.Now;
			var target1 = new Flight(sDate, DateTime.Now.AddDays(10), 10);
			var target2 = new Flight(sDate, DateTime.Now.AddDays(10), 10);
			Assert.IsFalse(target1.Equals(target2));
		}
		
		[Test()]
		public void TestFlightsInequalityDueToMiles()
		{
			DateTime sDate = DateTime.Now;
			DateTime rDate = DateTime.Now.AddDays(10);
			Flight target1 = new Flight(sDate, rDate, 10);
			Flight target2 = new Flight(sDate, rDate, 20);
			Assert.IsFalse(target1.Equals(target2));
		}
	}
}
