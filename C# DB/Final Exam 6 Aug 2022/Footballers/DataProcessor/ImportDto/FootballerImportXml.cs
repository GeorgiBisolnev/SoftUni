using Footballers.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class FootballerImportXml
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string ContractStartDate { get; set; }

        [Required]
        public string ContractEndDate { get; set; }

        public int BestSkillType { get; set; }

        public int PositionType { get; set; }
    }
}
