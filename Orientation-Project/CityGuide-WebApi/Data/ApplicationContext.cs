using CityGuide_WebApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.Data
{
    public class ApplicationContext: IdentityDbContext
    {
        public ApplicationContext(DbContextOptions options):base(options)
        {
               
        }
      

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<BaseTable> BaseTable { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<BlogModel> Blogs { get; set; }
        public DbSet<ApplicationModel> ApplicationModels { get; set; }
        public DbSet<EntityImages> EnitityImages { get;set; }

        public DbSet<TouristsAmenities> TouristsAmenities { get; set; }
        public DbSet<ActivitiesAmenities> ActivitiesAmenities { get; set; }
        public DbSet<FoodAmenities> FoodAmenities { get; set; }
        public DbSet<AccommodationAmenities> AccommodationAmenities { get; set; }

        public DbSet<BlogImage> blogImages { get; set; }
        public DbSet<UserBlog> userBlogs { get; set; }



    }
}
