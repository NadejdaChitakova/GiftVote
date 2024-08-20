using Bogus;
using GiftVote.Data.Context;
using GiftVote.Data.Models;
using Microsoft.AspNetCore.Builder;

namespace GiftVote.Data.Extensions
{
    public static class SeedDataExtension
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            var faker = new Faker();
            using var context = new IdentityDbContext();
            List<Gifts> gifts =
            [
                new Gifts("Chocolate"),
                new Gifts("Perfume"),
                new Gifts("Jewel")
            ];

            List<Employee> employees =
            [
                new Employee(faker.Person.FirstName, faker.Person.LastName, faker.Person.UserName, faker.Person.DateOfBirth),
                new Employee(faker.Person.FirstName, faker.Person.LastName, faker.Person.UserName, faker.Person.DateOfBirth),
                new Employee(faker.Person.FirstName, faker.Person.LastName, faker.Person.UserName, faker.Person.DateOfBirth),
                new Employee(faker.Person.FirstName, faker.Person.LastName, faker.Person.UserName, faker.Person.DateOfBirth)
            ];

            context.Set<Gifts>()
                .AddRange(gifts);

            context.Set<Employee>()
                .AddRange(employees);

            context.SaveChanges();
        }
    }
    }

