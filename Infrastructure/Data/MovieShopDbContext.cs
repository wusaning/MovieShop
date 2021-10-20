﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class MovieShopDbContext: DbContext
    {
        // get the connection string into constructor
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options) 
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // specify fluent API rules for your entities
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<User>(ConfigureUser);
        }


        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(256);
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");

            // we wanna tell EF to ignore Rating property and not create the column
            builder.Ignore(m => m.Rating);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.FirstName).HasMaxLength(30);
            builder.Property(m => m.LastName).HasMaxLength(30);
            //builder.Property(m => m.DateOfBirth).HasMaxLength(512);
            builder.Property(m => m.Email).HasMaxLength(100);
            builder.Property(m => m.HashedPassword).HasMaxLength(200);
            builder.Property(m => m.Salt).HasMaxLength(200);
            builder.Property(m => m.PhoneNumber).HasMaxLength(20);
            //builder.Property(m => m.TwoFactorEnabled).HasMaxLength(64);
            //builder.Property(m => m.LockoutEndDate).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            //builder.Property(m => m.LastLoginDateTime).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            //builder.Property(m => m.IsLocked).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            //builder.Property(m => m.AccessFailedCount).HasDefaultValueSql("getdate()");


        }

        // make sure our entity classes are represented as DbSets
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<User> User { get; set; }

    }
}
