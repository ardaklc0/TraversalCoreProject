﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;database=TraversalDB;Integrated Security=True;" +
                "Trusted_Connection=True;TrustServerCertificate=true;");
        }

        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<Destination> Destinations{ get; set; }
        public DbSet<FirstAbout> FirstAbouts{ get; set; }
        public DbSet<FirstFeature> FirstFeatures{ get; set; }
        public DbSet<Guide> Guides{ get; set; }
        public DbSet<Newsletter> Newsletters{ get; set; }
        public DbSet<SecondAbout> SecondAbouts{ get; set; }
        public DbSet<SecondFeature> SecondFeatures{ get; set; }
        public DbSet<SubAbout> SubAbouts{ get; set; }
        public DbSet<Testimonial> Testimonials{ get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
    }
}
