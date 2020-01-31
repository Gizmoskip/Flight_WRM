using System;
using System.Text;
using System.Globalization;

namespace Flight_WRM
{
    class Program
    {
        static void Main(string[] args)
        {
			City o = new City("Louisville, KY", 38.2527, 85.7585);
			City d = new City("Los Angeles, CA", 34.0522, 118.243680);

			Flight f = new Flight("BU Air", "A2972", o, d);
			Console.WriteLine(f.printFlightDetails());

			City o2 = new City("Louisville, KY", 38.2527, 85.7585);
			City d2 = new City("New York, NY", 40.7128, 74.0060);

			Flight f2 = new Flight("BU Air", "A2972", o2, d2);
			Console.WriteLine(f2.printFlightDetails());
		}
		/**
 * This class represents a City with
 * a name, lat and long.
 * @author Wade Muncy
 * @version 1.1;
 * PP1
 * 1.1: Converted to C#
 */
		public class City
		{

			private readonly String name;
			private readonly double latitude;
			private readonly double longitude;

			/**
			 * Empty-argument constructor to put 
			 * object into a consistent state.
			 */
			private City()
			{
				name = "";
				latitude = 0.0;
				longitude = 0.0;
			}//end constructor

			/**
			 * Constructor to instantiate the object.
			 * @param name
			 * @param latitude
			 * @param longitude
			 */
			public City(String name, double latitude, double longitude)
			{
				this.name = name;
				this.latitude = latitude;
				this.longitude = longitude;
			}//end constructor

			/**
			 * Getter for name
			 * @return
			 */
			public String getName()
			{
				return name;
			}//end getName

			/**
			 * Getter for latitude
			 * @return
			 */
			public double getLatitude()
			{
				return latitude;
			}//end getName

			/**
			 * Getter for longitude
			 * @return
			 */
			public double getLongitude()
			{
				return longitude;
			}


			override public String ToString()
			{
				return "City [name=" + name + ", latitude=" + latitude + ", longitude=" + longitude + "]";
			}
		}//end class

		/**
 * This object represents a flight
 * @author Wade Muncy
 * @version 1.1
 * PP1
 * 1.1: Converted to C#
 */

		

		public class Flight
		{
			private String airLineName;
			private City originCity;
			private City destinationCity;
			private String flightNumber;

			/**
			 * Empty-argument constructor to put 
			 * the object into a consistent state.
			 */
			public Flight()
			{
				airLineName = null;
				originCity = null;
				destinationCity = null;
				flightNumber = null;
			}//end constructor

			/**
			 * Preferred constructor for this object
			 * @param aln - airline number
			 * @param fn - flight number
			 * @param o - origin city
			 * @param d - destination city
			 */
			public Flight(String aln, String fn, City o, City d)
			{

				setAirLineName(aln);
				setFlightNumber(fn);
				setOriginCity(o);
				setDestinationCity(d);

			}//end constructor

			/**
			 * Method uses the haversine formulae
			 * to calculate the distance around the 
			 * globe from one city to another.
			 * @return - distance in miles
			 */
			public double calcDistanceToFly()
			{

				double R = 6371000;
				double lat1 = originCity.getLatitude();
				double lat2 = destinationCity.getLatitude();
				double lon1 = originCity.getLongitude();
				double lon2 = destinationCity.getLongitude();

				double lat1Radians = (Math.PI / 180) * lat1;
				double lat2Radians = (Math.PI / 180) * lat2;
				double lon1Radians = (Math.PI / 180) * lon1;
				double lon2Radians = (Math.PI / 180) * lon2;

				double deltaLat = (Math.PI / 180) * (lat2 - lat1);
				double deltaLon = (Math.PI / 180) * (lon2 - lon1);

				double a = Math.Pow(Math.Sin(deltaLat / 2), 2) + Math.Cos(lat1Radians) * Math.Cos(lat2Radians) * Math.Pow(Math.Sin(deltaLon / 2), 2);

				double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

				double distance = R * c;

				return distance * 0.000621371;
			}//end 

			/**
			 * This method will return all of the flight
			 * details including the airline, flight number,
			 * and distance between two city objects.
			 * @return -String representing the flight details
			 */
			public String printFlightDetails()
			{

				NumberFormatInfo formatter = NumberFormatInfo.CurrentInfo;

				StringBuilder sb = new StringBuilder();

				sb.Append(airLineName + " " + flightNumber + "\n");
				sb.Append(originCity.getName() + " to " + destinationCity.getName() + "\n");
				sb.Append("Distance: " + this.calcDistanceToFly().ToString("N", formatter) + " miles.\n");

				return sb.ToString();
			}//end printFlightDetails

			/**
			 * getter for airLineName
			 * @return
			 */
			public String getAirLineName()
			{
				return airLineName;
			}//end getAirline

			/**
			 * Setter for airLineName
			 * @param airLineName
			 */
			public void setAirLineName(String airLineName)
			{
				this.airLineName = airLineName;
			}//end setAirLineName

			/**
			 * Getter for flightNumber
			 * @return
			 */
			public String getFlightNumber()
			{
				return flightNumber;
			}//end getFlightNumber

			/**
			 * Setter for flightNumber
			 * @param flightNumber
			 */
			public void setFlightNumber(String flightNumber)
			{
				this.flightNumber = flightNumber;
			}//end setFlightNumber

			/**
			 * Getter for originCity
			 * @return
			 */
			public City getOriginCity()
			{
				return originCity;
			}//end getOriginCity

			/**
			 * Setter for originCity
			 * @param originCity
			 */
			public void setOriginCity(City originCity)
			{
				this.originCity = originCity;
			}//end setOriginCity

			/**
			 * Getter for destinationCity
			 * @return
			 */
			public City getDestinationCity()
			{
				return destinationCity;
			}//end getDestinationCity

			/**
			 * Setter for destinationCity
			 * @param destinationCity
			 */
			public void setDestinationCity(City destinationCity)
			{
				this.destinationCity = destinationCity;
			}//end setDestinationCity

			
			override public String ToString()
			{
				return "Flight [airLineName=" + airLineName + ", originCity=" + originCity + ", destinationCity="
						+ destinationCity + ", flightNumber=" + flightNumber + "]";
			}//end toString


		}//end class

	}
}
