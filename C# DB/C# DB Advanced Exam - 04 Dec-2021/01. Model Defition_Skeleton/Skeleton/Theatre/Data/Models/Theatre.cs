namespace Theatre.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Theatre
    {
        public Theatre()
        {
            this.Tickets = new List<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(sbyte), "1", "10")]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Director { get; set; }


        public ICollection<Ticket> Tickets { get; set; }
    }
}
    //• Id – integer, Primary Key
    //• Name – text with length [4, 30] (required)
    //• NumberOfHalls – sbyte between[1…10] (required)
    //• Director – text with length [4, 30] (required)
    //• Tickets - a collection of type Ticket
