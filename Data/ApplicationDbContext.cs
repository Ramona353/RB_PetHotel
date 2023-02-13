using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RB_PetHotel.Models.DBObjects;
using RB_PetHotel.Models;

namespace RB_PetHotel.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Pet> Pets { get; set; } = null!;
        public virtual DbSet<PetOwner> PetOwners { get; set; } = null!;
        public virtual DbSet<PetRoom> PetRooms { get; set; } = null!;
        public virtual DbSet<PetService> PetServices { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("owners");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("owner_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("pets");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Breed)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("breed");

                entity.Property(e => e.PetName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pet_name");

                entity.Property(e => e.SpecialNeeds)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("special_needs");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("weight");
            });

            modelBuilder.Entity<PetOwner>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pet_owner");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.HasOne(d => d.Owner)
                    .WithMany()
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK__pet_owner__owner__31EC6D26");

                entity.HasOne(d => d.Pet)
                    .WithMany()
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__pet_owner__pet_i__30F848ED");
            });

            modelBuilder.Entity<PetRoom>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pet_room");

                entity.Property(e => e.CheckInDate)
                    .HasColumnType("date")
                    .HasColumnName("check_in_date");

                entity.Property(e => e.CheckOutDate)
                    .HasColumnType("date")
                    .HasColumnName("check_out_date");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.HasOne(d => d.Pet)
                    .WithMany()
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__pet_room__pet_id__2B3F6F97");

                entity.HasOne(d => d.Room)
                    .WithMany()
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__pet_room__room_i__2C3393D0");
            });

            modelBuilder.Entity<PetService>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pet_service");

                entity.Property(e => e.DateAdded)
                    .HasColumnType("date")
                    .HasColumnName("date_added");

                entity.Property(e => e.PetId).HasColumnName("pet_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Pet)
                    .WithMany()
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__pet_servi__pet_i__2E1BDC42");

                entity.HasOne(d => d.Service)
                    .WithMany()
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__pet_servi__servi__2F10007B");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("rooms");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.Occupancy).HasColumnName("occupancy");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("room_number");

                entity.Property(e => e.RoomType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("room_type");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("service_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<RB_PetHotel.Models.OwnerModel> OwnerModel { get; set; }

        public DbSet<RB_PetHotel.Models.PetOwnerModel> PetOwnerModel { get; set; }

        public DbSet<RB_PetHotel.Models.PetModel> PetModel { get; set; }

        public DbSet<RB_PetHotel.Models.PetRoomModel> PetRoomModel { get; set; }

        public DbSet<RB_PetHotel.Models.PetServiceModel> PetServiceModel { get; set; }

        public DbSet<RB_PetHotel.Models.RoomModel> RoomModel { get; set; }

        public DbSet<RB_PetHotel.Models.ServiceModel> ServiceModel { get; set; }

        public DbSet<RB_PetHotel.Models.UserModel> UserModel { get; set; }
    }
}
