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
                GiftFactory("Chocolate"),
                GiftFactory("Parfume"),
                GiftFactory("Jewel")
            ];

            List<Employee> employees = 
            [
                EmployeeFactory(faker.Person.FirstName, faker.Person.LastName, faker.Person.UserName),
                EmployeeFactory(faker.Person.FirstName, faker.Person.LastName, faker.Person.UserName),
                EmployeeFactory(faker.Person.FirstName, faker.Person.LastName, faker.Person.UserName),
                EmployeeFactory(faker.Person.FirstName, faker.Person.LastName, faker.Person.UserName)
                                       ];
            context.Set<Gifts>()
                .AddRange(gifts);

        }

        private static Gifts GiftFactory(string name)
        => new()
{
Name = name
};

        private static Employee EmployeeFactory(string firstname, string lastname, string username)
            => new()
            {
                FirstName = firstname,
                LastName = lastname,
                UserName = username,
                Password = BCrypt.Net.BCrypt.HashPassword(username)
            };
    }
    }

