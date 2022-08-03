using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("Product")]
    public class ProductsImportDto
    {
        [XmlElement("name")]
        public string  Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("sellerId")]
        public int SellerId { get; set; }

        [XmlElement("buyerId")]
        public int? BuyerId { get; set; }
    }
}

//< Products >
//    < Product >
//        < name > Care One Hemorrhoidal</name>
//        <price>932.18</price>
//        <sellerId>25</sellerId>
//        <buyerId>24</buyerId>
//    </Product>
