﻿

namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Town> Towns { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionstring =
                @"Server=DESKTOPPC\DEVSQL;Database=Bet377;Integrated Security=True"; 
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionstring);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<PlayerStatistic>(e =>
                {
                    e.HasKey(ps => new
                    {
                        ps.PlayerId,
                        ps.GameId
                    });
                });

            modelBuilder
                .Entity<Game>(e =>
                {
                    e
                        .HasOne(g => g.HomeTeam)
                        .WithMany(t => t.HomeGames)
                        .HasForeignKey(g => g.HomeTeamId)
                        .OnDelete(DeleteBehavior.NoAction);

                    e
                        .HasOne(g => g.AwayTeam)
                        .WithMany(t => t.AwayGames)
                        .HasForeignKey(g => g.AwayTeamId)
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder
                .Entity<Team>(e =>
                {
                    e
                        .HasOne(p => p.PrimaryKitColor)
                        .WithMany(c => c.PrimaryKitTeams)
                        .HasForeignKey(p => p.PrimaryKitColorId)
                        .OnDelete(DeleteBehavior.NoAction);

                    e
                        .HasOne(s => s.SecondaryKitColor)
                        .WithMany(c => c.SecondaryKitTeams)
                        .HasForeignKey(s => s.SecondaryKitColorId)
                        .OnDelete(DeleteBehavior.NoAction);
                });
        }
    }
}