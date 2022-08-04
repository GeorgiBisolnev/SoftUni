using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportPrisonerWithMailsDto
    {
        [JsonProperty("FullName")]
        [Required]
        [StringLength(20,MinimumLength =3)]
        public string FullName { get; set; }

        [JsonProperty("Nickname")]
        [Required]
        [RegularExpression("^The [A-Z][a-z]*$")]
        public string NickName { get; set; }

        [JsonProperty("Age")]
        [Range(18,65)]
        public int Age { get; set; }

        [JsonProperty("IncarcerationDate")]
        [Required]
        public string IncarcerationDate { get; set; }

        [JsonProperty("ReleaseDate")]
        public string ReleaseDate { get; set; }

        [JsonProperty("Bail")]
        [Range(typeof(decimal),"0", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }

        [JsonProperty("CellId")]
        public int? CellId { get; set; }

        [JsonProperty("Mails")]
        public ImportPrisonerMailsDto[] Mails { get; set; }
    }
}

//    "FullName": "",
//    "Nickname": "The Wallaby",
//    "Age": 32,
//    "IncarcerationDate": "29/03/1957",
//    "ReleaseDate": "27/03/2006",
//    "Bail": null,
//    "CellId": 5,
//    "Mails": [
//      {
//        "Description": "Invalid FullName",
//        "Sender": "Invalid Sender",
//        "Address": "No Address"
//      },
