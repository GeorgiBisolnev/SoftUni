

namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}
