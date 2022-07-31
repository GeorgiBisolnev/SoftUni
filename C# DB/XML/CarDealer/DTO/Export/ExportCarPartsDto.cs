using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Export
{
    [XmlType("part")]
    public class ExportCarPartsDto
    {
        [XmlAttribute("name")]
        public string  Name { get; set; }


        [XmlAttribute("price")]
        public decimal Price { get; set; }


    }
}
