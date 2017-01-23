using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace GlobalWeatherClient.Models
{
    [XmlRoot("NewDataSet")]
    public class NewDataSet
    {
        [XmlElement("Table")]
        public List<Table> Tables { get; set; }
    }
}