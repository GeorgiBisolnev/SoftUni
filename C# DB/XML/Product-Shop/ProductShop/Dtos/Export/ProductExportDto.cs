using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Product")]
    public class ProductExportDto
    {
        [XmlElement("name")]
        public string Name { get; set; }


        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]

        public string Buyer { get; set; }
    }
}

//< Products >
//  < Product >
//    < name > TRAMADOL HYDROCHLORIDE </ name >
//    < price > 516.48 </ price >
//  </ Product >
