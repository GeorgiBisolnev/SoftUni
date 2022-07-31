using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Export
{
    [XmlType("car")]
    public class ExportSalesWithDiscountCarDto
    {

        [XmlAttribute("make")]
        public string Make { get; set; }


        [XmlAttribute("model")]
        public string Model { get; set; }


        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }


    }
}
