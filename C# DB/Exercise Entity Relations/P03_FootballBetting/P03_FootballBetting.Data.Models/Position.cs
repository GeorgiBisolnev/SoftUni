﻿namespace P03_FootballBetting.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }
        [Key]
        public int PositionId { get; set; }

        [Required]
        public string  Name { get; set; }

        public virtual ICollection<Player>  Players { get; set; }
    }
}
