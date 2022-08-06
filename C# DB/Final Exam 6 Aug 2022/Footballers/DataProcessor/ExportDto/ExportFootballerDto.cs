using Footballers.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Footballer")]
    public class ExportFootballerDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Position")]
        public PositionType Position { get; set; }
    }
}
