using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Data.Models;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType(nameof(Play))]
    public class ImportPlayDto
    {

        [Required]
        [StringLength(50, MinimumLength = 4)]
        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Duration")]
        [Required (AllowEmptyStrings = false)]
        public string Duration { get; set; }

        [XmlElement("Rating")]
        [Range(typeof(float), "0.00", "10.00")]
        public float Rating { get; set; }

        [Required]
        [XmlElement("Genre")]
        public string Genre { get; set; }

        [Required(AllowEmptyStrings =false)]
        [MaxLength(700)]
        [XmlElement("Description")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(30, MinimumLength = 4)]
        [XmlElement("Screenwriter")]
        public string Screenwriter { get; set; }

    }
}

//< Plays >
//  < Play >
//    < Title > The Hsdfoming </ Title >
//    < Duration > 03:40:00 </ Duration >
//    < Rating > 8.2 </ Rating >
//    < Genre > Action </ Genre >
//    < Description > A guyat Pinter turns into a debatable conundrum as oth ordinary and menacing. Much of this has to do with the fabled "Pinter Pause," which simply mirrors the way we often respond to each other in conversation, tossing in remainders of thoughts on one subject well after having moved on to another.</Description>
//    <Screenwriter>Roger Nciotti</Screenwriter>
//  </Play>