using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class UserSoldExportDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }


        [XmlElement("lastName")]
        public string LasteName { get; set; }

        [XmlArray("soldProducts")]
        public ExportSoldProductsDto[] ExportSoldProductsDto { get; set; }
    }
}
