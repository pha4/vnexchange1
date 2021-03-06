﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vnexchange1.Models;

namespace vnexchange1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<vnexchange1.Models.Category> Category { get; set; }

        public DbSet<vnexchange1.Models.ItemImage> ItemImage { get; set; }

        public DbSet<vnexchange1.Models.Item> Item { get; set; }

        public DbSet<vnexchange1.Models.Location> Location { get; set; }

        public DbSet<ItemType> ItemType { get; set; }

        public DbSet<UserRating> UserRating { get; set; }

        public DbSet<ItemComment> ItemComment { get; set; }

        public DbSet<vnexchange1.Models.ItemRequest> ItemRequest { get; set; }
    }
}
