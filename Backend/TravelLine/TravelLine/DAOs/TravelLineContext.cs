using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelLine.Models;

namespace TravelLine.DAOs
{
    public class TravelLineContext : DbContext
    {
        public TravelLineContext(DbContextOptions<TravelLineContext> options) : base(options)
        {

        }

        //DB Sets
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Multimedia> Multimedias { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User friends
            modelBuilder.Entity<Friends>()
             .HasOne(e => e.User1)
             .WithMany(e => e.Friends);

            modelBuilder.Entity<Friends>()
                .HasOne(e => e.User2)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            //Default date in post
            modelBuilder.Entity<Post>()
                .Property(b => b.PostDate)
                .HasDefaultValueSql("getdate()");

            //Default date in user
            modelBuilder.Entity<User>()
                .Property(b => b.Date)
                .HasDefaultValueSql("getdate()");
            
            //Default date in tag
            modelBuilder.Entity<Tag>()
                .Property(b => b.Date)
                .HasDefaultValueSql("getdate()");
        }
    }
}
