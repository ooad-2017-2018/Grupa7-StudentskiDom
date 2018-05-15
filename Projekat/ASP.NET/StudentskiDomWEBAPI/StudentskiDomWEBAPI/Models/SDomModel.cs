namespace StudentskiDomWEBAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SDomModel : DbContext
    {
        public SDomModel()
            : base("name=SDomModel")
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Blagajnik> Blagajnik { get; set; }
        public virtual DbSet<Konobar> Konobar { get; set; }
        public virtual DbSet<Kuhar> Kuhar { get; set; }
        public virtual DbSet<Majstor> Majstor { get; set; }
        public virtual DbSet<SefRestorana> SefRestorana { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<Admin>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<Admin>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<Blagajnik>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<Blagajnik>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<Blagajnik>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<Konobar>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<Konobar>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<Konobar>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<Kuhar>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<Kuhar>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<Kuhar>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<Majstor>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<Majstor>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<Majstor>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<SefRestorana>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<SefRestorana>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<SefRestorana>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<Student>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<Student>()
                .Property(e => e.version)
                .IsFixedLength();
        }
    }
}
