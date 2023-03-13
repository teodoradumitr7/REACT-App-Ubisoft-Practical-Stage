using System;
using CRUD_GAME_APPLICATION.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CRUD_GAME_APPLICATION.Data
{
    public partial class GamesContext : DbContext
    {
        public GamesContext()
        {
        }

        public GamesContext(DbContextOptions<GamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GamesDeveloper> GamesDevelopers { get; set; }
        public virtual DbSet<GamesPlatform> GamesPlatforms { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-7VS1V34;Initial Catalog=CRUD_API;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Developer>(entity =>
            {
                entity.HasKey(e => e.IdDeveloper)
                    .HasName("PK__develope__8B723FBE9B65BE11");

                entity.ToTable("developers");

                entity.Property(e => e.IdDeveloper).HasColumnName("id_developer");

                entity.Property(e => e.DeveloperName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("developer_name");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.IdGame)
                    .HasName("PK__games__0E819B2C8FDD3929");

                entity.ToTable("games");

                entity.Property(e => e.IdGame).HasColumnName("id_game");

                entity.Property(e => e.Edition)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("edition");

                entity.Property(e => e.GameName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("game_name");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("genre");

                entity.Property(e => e.LaunchDate)
                    .HasColumnType("date")
                    .HasColumnName("launch_date");

                entity.Property(e => e.Multiplayer).HasColumnName("multiplayer");

                entity.Property(e => e.Storage).HasColumnName("storage");
            });

            modelBuilder.Entity<GamesDeveloper>(entity =>
            {
                entity.HasKey(e => new { e.IdGame, e.IdDeveloper })
                    .HasName("PK_GAME_DEVELOPERS");

                entity.ToTable("games_developers");

                entity.Property(e => e.IdGame).HasColumnName("id_game");

                entity.Property(e => e.IdDeveloper).HasColumnName("id_developer");

                entity.Property(e => e.WorkedHours).HasColumnName("worked_hours");

                  entity.HasOne(d => d.IdDeveloperNavigation)
                      .WithMany(p => p.GamesDevelopers)
                      .HasForeignKey(d => d.IdDeveloper)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_DEVELOPERS");
              

                entity.HasOne(d => d.IdGameNavigation)
                    .WithMany(p => p.GamesDevelopers)
                    .HasForeignKey(d => d.IdGame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GAMES");
            });

            modelBuilder.Entity<GamesPlatform>(entity =>
            {
                entity.HasKey(e => new { e.IdGame, e.IdPlatform })
                    .HasName("PK_GAME_PLATFORMS");

                entity.ToTable("games_platforms");

                entity.Property(e => e.IdGame).HasColumnName("id_game");

                entity.Property(e => e.IdPlatform).HasColumnName("id_platform");

                entity.HasOne(d => d.IdGameNavigation)
                    .WithMany(p => p.GamesPlatforms)
                    .HasForeignKey(d => d.IdGame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GAMES1");

                entity.HasOne(d => d.IdPlatformNavigation)
                    .WithMany(p => p.GamesPlatforms)
                    .HasForeignKey(d => d.IdPlatform)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PLATFORM");
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.HasKey(e => e.IdPlatform)
                    .HasName("PK__platform__4B55E5B20A4EF7E4");

                entity.ToTable("platforms");

                entity.Property(e => e.IdPlatform).HasColumnName("id_platform");

                entity.Property(e => e.PlatformName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("platform_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdGame })
                    .HasName("PK_USERS");

                entity.ToTable("users");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IdGame).HasColumnName("id_game");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("username");

                entity.HasOne(d => d.IdGameNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdGame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GAMES3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
