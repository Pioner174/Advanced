using Microsoft.EntityFrameworkCore;

namespace Advanced.Models
{
    public static class SeedData
    {
        public static void SeedDatabase(DataContext contex)
        {
            contex.Database.Migrate();

            if(contex.People.Count() == 0 && contex.Departments.Count() == 0 && contex.Locations.Count() == 0)
            {
                Department d1 = new Department {Name = "Sales" };
                Department d2 = new Department { Name = "Development" };
                Department d3 = new Department { Name = "Support" };
                Department d4 = new Department { Name = "Facilities" };

                contex.Departments.AddRange(d1, d2, d3, d4);
                contex.SaveChanges();

                Location l1 = new Location { City = "Oakland", Region = "CA"};
                Location l2 = new Location { City = "San Jose", Region = "CA" };
                Location l3 = new Location { City = "New York", Region = "NY" };
                Location l4 = new Location { City = "Washington", Region = "WA" };

                contex.Locations.AddRange(l1, l2, l3, l4);

                contex.People.AddRange(
                    new Person
                    {
                        FirstName = "Francesca",
                        Surname = "Jacobs",
                        Department = d1,
                        Location = l1
                    },
                    new Person
                    {
                        FirstName = "Daniel",
                        Surname = "Duglas",
                        Department = d3,
                        Location = l4
                    },
                    new Person
                    {
                        FirstName = "Valeria",
                        Surname = "Scripach",
                        Department = d2,
                        Location = l3
                    },
                    new Person
                    {
                        FirstName = "Evgeniy",
                        Surname = "Maroon",
                        Department = d4,
                        Location = l4
                    },
                    new Person
                    {
                        FirstName = "Vladislav",
                        Surname = "Turn",
                        Department = d1,
                        Location = l3
                    },
                    new Person
                    {
                        FirstName = "Roman",
                        Surname = "Matanin",
                        Department = d2,
                        Location = l1
                    },
                    new Person
                    {
                        FirstName = "Egor",
                        Surname = "Perol",
                        Department = d3,
                        Location = l3
                    },
                    new Person
                    {
                        FirstName = "Alex",
                        Surname = "Marcan",
                        Department = d4,
                        Location = l2
                    },
                    new Person
                    {
                        FirstName = "Marcus",
                        Surname = "Pasta",
                        Department = d2,
                        Location = l1
                    },
                    new Person
                    {
                        FirstName = "Petr",
                        Surname = "Lloyd",
                        Department = d1,
                        Location = l3
                    });
                contex.SaveChanges();
            }
        }

    }
}
