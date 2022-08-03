using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("User")]
    public class UsersImportDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int Age { get; set; }
    }
}

//< Users >
//    < User >
//        < firstName > Chrissy </ firstName >
//        < lastName > Falconbridge </ lastName >
//        < age > 50 </ age >
//    </ User >
