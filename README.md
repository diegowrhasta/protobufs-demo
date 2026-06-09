# Notes

You need to have a definition, so a `.proto` file. And it has its own conventions, its own syntax and all.

With:

- Google.Protobuf
- Grpc.Tools

And marking the proto file in your csproj:

````xml
<ItemGroup>
        <Protobuf Include="person.proto" />
</ItemGroup>
````

Then .NET will take care of generating behind the scenes the auto-generated C# class and its related methods that are then 
open to your usage

## Streams or Byte arrays

For small messages, byte arrays are fine `byte[]`, but for large messages or network/file scenarios `Stream` is better

## Extra QoL methods

The auto-generated classes, are actually super complex, and have tons of methods that help you out the box to work with 
bytes, arrays to serialize, deserialize, you just need to access the respective property and method.

E.g., `Person.Parser.ParseFrom(...)`