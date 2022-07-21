namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public  class User
    {

        public User()
        {
            this.Bets = new HashSet<Bet>();
        }
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [MaxLength(320)]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Balance { get; set; }

        public ICollection<Bet> Bets  { get; set; }
    }
}
