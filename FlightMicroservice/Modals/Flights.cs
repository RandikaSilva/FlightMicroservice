using System;
using System.Xml.Serialization;

namespace FlightMicroservice.Modals
{
    [XmlRoot("Flights")]
    public class Flights
    {
        [XmlElement("Flight")]
        public Flight[] FlightList { get; set; }
    }
}

