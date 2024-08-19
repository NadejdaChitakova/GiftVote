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
            using (var context = new IdentityDbContext())
            {
                List<Gifts> gifts =
                [
                    Gifts.GiftFactory("Chocolate"),
                    Gifts.GiftFactory("Perfume"),
                    Gifts.GiftFactory("Jewel")
                ];

                List<Employee> employees =
                [
Employee.EmployeeFactory(faker.Person.FirstName, faker.Person.LastName, faker.Person.UserName),
Employee.EmployeeFactory(faker.Person.FirstName, faker.Person.LastName, faker.Person.UserName),
Employee.EmployeeFactory(faker.Person.FirstName, faker.Person.LastName, faker.Person.UserName),
Employee.EmployeeFactory(faker.Person.FirstName, faker.Person.LastName, faker.Person.UserName)
                ];

                context.Set<Gifts>()
                    .AddRange(gifts);

                context.Set<Employee>()
                    .AddRange(employees);

                context.SaveChanges();
            }
        }
    }
    }

