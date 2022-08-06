using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class CoachImportXml
    {
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        [XmlArray("Footballers")]
        public FootballerImportXml[] Footballers { get; set; }
    }
}
