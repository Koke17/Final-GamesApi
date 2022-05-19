using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VideogamesApi
{
    public partial class GamesDbContext : DbContext
    {
        public GamesDbContext()
        {
        }

        public GamesDbContext(DbContextOptions<GamesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DevelopmentStudio> DevelopmentStudios { get; set; }
        public virtual DbSet<DevelopmentStudioVideogame> DevelopmentStudioVideogames { get; set; }
        public virtual DbSet<Engine> Engines { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<GenreVideogame> GenreVideogames { get; set; }
        public virtual DbSet<Videogame> Videogames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAP-CSN002\\SQLEXPRESS01;Database=GamesDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<DevelopmentStudio>(entity =>
            {
                entity.ToTable("Development_Studio");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FoundationDate)
                    .HasColumnType("date")
                    .HasColumnName("Foundation_Date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DevelopmentStudioVideogame>(entity =>
            {
                entity.HasKey(r => new { r.DevelopmentStudioId, r.VideogameId });

                entity.ToTable("Development_StudioVideogame");

                entity.Property(e => e.DevelopmentStudioId).HasColumnName("Development_Studio_ID");

                entity.Property(e => e.VideogameId).HasColumnName("Videogame_ID");

                entity.HasOne(d => d.DevelopmentStudio)
                    .WithMany(d => d.DevelopmentStudioVideogame)
                    .HasForeignKey(d => d.DevelopmentStudioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Development_StudioVideogame_Development_Studio");

                entity.HasOne(d => d.Videogame)
                    .WithMany(d => d.DevelopmentStudioVideogame)
                    .HasForeignKey(d => d.VideogameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Development_StudioVideogame_Videogame");
            });

            modelBuilder.Entity<Engine>(entity =>
            {
                entity.ToTable("Engine");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DevelopmentStudioId).HasColumnName("Development_Studio_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProgrammingLanguage)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Programming_Language");

                entity.HasOne(d => d.DevelopmentStudio)
                    .WithMany(p => p.Engines)
                    .HasForeignKey(d => d.DevelopmentStudioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Engine_Development_Studio");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GenreVideogame>(entity =>
            {
                entity.HasKey(r => new { r.GenreId, r.VideogameId });

                entity.ToTable("GenreVideogame");

                entity.Property(e => e.GenreId).HasColumnName("Genre_ID");

                entity.Property(e => e.VideogameId).HasColumnName("Videogame_ID");

                entity.HasOne(d => d.Genre)
                    .WithMany(d => d.GenreVideogame)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GenreVideogame_Genre");

                entity.HasOne(d => d.Videogame)
                    .WithMany(d => d.GenreVideogame)
                    .HasForeignKey(d => d.VideogameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GenreVideogame_Videogame");
            });

            modelBuilder.Entity<Videogame>(entity =>
            {
                entity.HasKey(r => r.Id );

                entity.ToTable("Videogame");

                //entity.Property(e => e.Id)
                //    .ValueGeneratedOnAdd()
                //    .HasColumnName("ID");

                entity.Property(e => e.EngineId).HasColumnName("Engine_ID");

                entity.Property(e => e.Mode).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Engine)
                    .WithMany(p => p.Videogames)
                    .HasForeignKey(d => d.EngineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Videogame_Engine");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
