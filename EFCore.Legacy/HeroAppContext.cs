using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCore.Legacy
{
    public partial class HeroAppContext : DbContext
    {
        public HeroAppContext()
        {
        }

        public HeroAppContext(DbContextOptions<HeroAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Battle> Battles { get; set; }
        public virtual DbSet<Hero> Heroes { get; set; }
        public virtual DbSet<HeroesBattle> HeroesBattles { get; set; }
        public virtual DbSet<SecretId> SecretIds { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HeroApp;Data Source=DESKTOP-QE6TO2U");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<HeroesBattle>(entity =>
            {
                entity.HasKey(e => new { e.BattleId, e.HeroId });

                entity.HasIndex(e => e.HeroId, "IX_HeroesBattles_HeroId");

                entity.HasOne(d => d.Battle)
                    .WithMany(p => p.HeroesBattles)
                    .HasForeignKey(d => d.BattleId);

                entity.HasOne(d => d.Hero)
                    .WithMany(p => p.HeroesBattles)
                    .HasForeignKey(d => d.HeroId);
            });

            modelBuilder.Entity<SecretId>(entity =>
            {
                entity.HasIndex(e => e.HeroId, "IX_SecretIds_HeroId")
                    .IsUnique();

                entity.HasOne(d => d.Hero)
                    .WithOne(p => p.SecretId)
                    .HasForeignKey<SecretId>(d => d.HeroId);
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.HasIndex(e => e.HeroId, "IX_Weapons_HeroId");

                entity.HasOne(d => d.Hero)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.HeroId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
