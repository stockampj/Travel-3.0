using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Travel.Models;

namespace Travel.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users {get; set;}
        public DbSet<Review> Reviews {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<City>()
                .HasData(
                    new City {CityId = 3, CityName = "Los Angelos", CountryId = 1},
                    new City {CityId = 4, CityName = "Paris", CountryId = 2},
                    new City {CityId = 5, CityName = "Venice", CountryId = 3},
                    new City {CityId = 6, CityName = "Hong Kong", CountryId = 4},
                    new City {CityId = 7, CityName = "London", CountryId = 5},
                    new City {CityId = 8, CityName = "Delhi", CountryId = 6},
                    new City {CityId = 9, CityName = "Nairobi", CountryId = 7},
                    new City {CityId = 10, CityName = "Bali", CountryId = 8},
                    new City {CityId = 11, CityName = "Brasilia", CountryId = 9},
                    new City {CityId = 12, CityName = "Portland", CountryId = 1}
                );

            builder.Entity<Country>()
                .HasData(
                    new Country {CountryId = 1, CountryName = "USA"},
                    new Country {CountryId = 2, CountryName = "France"},
                    new Country {CountryId = 3, CountryName = "Italy"},
                    new Country {CountryId = 4, CountryName = "Hong Kong"},
                    new Country {CountryId = 5, CountryName = "England"},
                    new Country {CountryId = 6, CountryName = "India"},
                    new Country {CountryId = 7, CountryName = "Kenya"},
                    new Country {CountryId = 8, CountryName = "Indonesia"},
                    new Country {CountryId = 9, CountryName = "Brasil"}
                );

            builder.Entity<User>()
                .HasData(
                    new User {UserId = 3, UserName = "Dom"},
                    new User {UserId = 4, UserName = "Jen"},
                    new User {UserId = 5, UserName = "Anita"},
                    new User {UserId = 6, UserName = "Devin"},
                    new User {UserId = 7, UserName = "Hailey"},
                    new User {UserId = 8, UserName = "Neha"},
                    new User {UserId = 9, UserName = "Joel"},
                    new User {UserId = 10, UserName = "Kira"},
                    new User {UserId = 11, UserName = "Molly"},
                    new User {UserId = 12, UserName = "Sofia"}
                );

            builder.Entity<Review>()
                .HasData(
                    new Review {ReviewId = 3, Rating = 2, UserId = 3, CityId = 3, Blurb = "t vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero"},
                    new Review {ReviewId = 4, Rating = 4, UserId = 3, CityId = 3, Blurb = "t vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero"},
                    new Review {ReviewId = 5, Rating = 5, UserId = 4, CityId = 6, Blurb = "t vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero"},
                    new Review {ReviewId = 6, Rating = 3, UserId = 4, CityId = 7, Blurb = "t vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero"},
                    new Review {ReviewId = 7, Rating = 1, UserId = 5, CityId = 10, Blurb = "t vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero"},
                    new Review {ReviewId = 8, Rating = 2, UserId = 7, CityId = 12, Blurb = "t vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero"},
                    new Review {ReviewId = 9, Rating = 4, UserId = 8, CityId = 4, Blurb = "t vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero"},
                    new Review {ReviewId = 10, Rating = 5, UserId = 12, CityId = 5, Blurb = "t vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero"},
                    new Review {ReviewId = 11, Rating = 4, UserId = 10, CityId = 5, Blurb = "t vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero"},
                    new Review {ReviewId = 12, Rating = 3, UserId = 6, CityId = 9, Blurb = "t vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero"}
                );
        }
    }
}