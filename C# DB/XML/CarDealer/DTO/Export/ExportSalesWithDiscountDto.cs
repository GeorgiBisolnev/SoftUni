using System.Xml.Serialization;

namespace CarDealer.DTO.Export
{
    [XmlType("sale")]
    public class ExportSalesWithDiscountDto
    {
        [XmlElement("car")]
        public ExportSalesWithDiscountCarDto Car { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public double Price { get; set; }

        [XmlElement("price-with-discount")]
        public double PriceWithDiscount { get; set; }

    }
}
