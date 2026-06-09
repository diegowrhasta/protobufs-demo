// See https://aka.ms/new-console-template for more information

using Google.Protobuf;
using Protobuffs.Tests;
using ProtoDemo;

// Simple usage of auto-generated class (from .proto file)

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

// Serialize to Byte Array

var bytes = person.ToByteArray();

Console.WriteLine($"Serialized size: {bytes.Length} bytes");

// Serialize to a Stream

using var memoryStream = new MemoryStream(bytes);

person.WriteTo(memoryStream);

Console.WriteLine($"Serialized: {memoryStream.Length}");

// Serialize to a File

await using var fileStream =
    File.Create("person.bin");

person.WriteTo(fileStream);

// Deserialization from Byte Array

var bytes2 = person.ToByteArray();

Person restored = Person.Parser.ParseFrom(bytes2);

Console.WriteLine(restored.FirstName);

// Deserialization from a Stream

// After writing `WriteTo(memoryStream)` the stream cursor is at the end. So reset it first
memoryStream.Position = 0;

restored = Person.Parser.ParseFrom(memoryStream);

Console.WriteLine(restored.FirstName);

// Deserialization from a File

// await using var file =
//     File.OpenRead("person.bin");
//
// Person restored =
//     Person.Parser.ParseFrom(file);
//
// Console.WriteLine(restored.FirstName);

OneOfExample.Run();