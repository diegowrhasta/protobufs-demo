// See https://aka.ms/new-console-template for more information
using ProtoDemo;

var person = new Person
{
    Id = 1001,
    FirstName = "Diego",
    LastName = "Balderrama",
    Active = true,
    Salary = 120000,
    Address = new Address
    {
        Street = "123 Main St",
        City = "Tokyo"
    }
};

person.Skills.Add("C#");
person.Skills.Add(".NET");
person.Skills.Add("Docker");

Console.WriteLine(person);

