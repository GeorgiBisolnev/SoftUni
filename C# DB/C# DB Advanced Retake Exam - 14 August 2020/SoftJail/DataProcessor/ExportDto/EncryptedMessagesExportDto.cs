using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class EncryptedMessagesExportDto
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
