using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace GlobalWeatherClient.Models
{
    
    public class Table
    {
        [XmlElement("Country")]
        public string Country { get; set; }
        [XmlElement("City")]
        public string City { get; set; }
    }
}