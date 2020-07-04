using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoprawaKolokwium.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Action> Actions { get; set; }
        public DbSet<Firefighter> Firefighters { get; set; }
        public DbSet<FireTruck> FireTrucks { get; set; }
        public DbSet<Firefighter_Action> Firefighter_Actions { get; set; }
        public DbSet<Firetruck_Action> Firetruck_Actions { get; set; }

        public MyContext() { }

        public MyContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Action>(ent =>
            {
                // PK
                ent.HasKey(e => e.IdAction);
                // Ograniczenia
                ent.Property(e => e.StartTime)
                .IsRequired();
                ent.Property(e => e.NeedSpecialEquipment)
                .IsRequired();
            });

            modelBuilder.Entity<FireTruck>(ent =>
            {
                // PK
                ent.HasKey(e => e.IdFiretruck);
                // Ograniczenia
                ent.Property(e => e.OperationalNumber)
                .IsRequired()
                .HasMaxLength(10);
                ent.Property(e => e.SpecialEquipment)
                .IsRequired();
            });

            modelBuilder.Entity<Firefighter>(ent =>
            {
                // PK
                ent.HasKey(e => e.IdFirefighter);
                // Ograniczenia
                ent.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsRequired();
                ent.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsRequired();

            });

            modelBuilder.Entity<Firefighter_Action>(ent =>
            {
                // PK+FK
                ent.HasKey(e => new { e.IdFirefighter, e.IdAction });
            });

            modelBuilder.Entity<Firetruck_Action>(ent =>
            {
                // PK
                ent.HasKey(e => e.IdFiretruckAction);
                // FK
                ent.HasKey(e => new { e.IdAction, e.IdFiretruck });

                ent.Property(e => e.AssigmentDate)
                .IsRequired();
            });

        }
    }
}
