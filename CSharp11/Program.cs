using CSharp11;

internal class Program
{
    private static void Main(string[] args)
    {
        //comment out the relevant methods to see the functionality individually.
        StringUpdates();
        GenericMathSupport.NewMathChanges();
        RecordExample();
        PatternMatchingExample();
    }

    public static void StringUpdates()
    {
        //New for c#11 is string literals, denoted by 3 double quotes (")
        string stringLiteral = """
        {
         "Logging": {
            "LogLevel":{
                "Default": "Information"
            }
         }
        }
        """;
        Console.WriteLine(stringLiteral);


        //--------------------------------------------------------------------------------------------------
        // string literals also support interpolation

        var option = 2;

        //new pattern matching syntax switch expression
        var loggingValue = option switch
        {
            1 => "Information",
            2 => "Debug",
            3 => "Info",
            _ => throw new ArgumentOutOfRangeException("option") // "_" represents the default
        };

        // old style switch statement, more verbose. 
        /*switch (option)
        {
            case 1:
                loggingValue = "Information";
                break;
            case 2:
                loggingValue = "Debug";
                break;
            case 3:
                loggingValue = "Info";
                break;
            default:
                throw new ArgumentOutOfRangeException("option")
        }*/

        //using a double dollar sign on a literal string allows interpolation using double braces "{{}}"
        string stringLiteralInterpolation = $$"""
        {
            "Logging": {
            "LogLevel":{
                "Default": "{{loggingValue}}"
            }
            }
        }
        """;

        Console.WriteLine(stringLiteralInterpolation);

        // you can even go overboard with the interpolation as they now support multi-line statements
        // but I feel this is borderline criminal. Might have a use somewhere.
        string multiLineInterpolation = $$"""
        {
         "Logging": {
            "LogLevel":{
                "Default": "{{option switch
        {
            1 => "Information",
            2 => "Debug",
            3 => "Info",
            _ => throw new ArgumentOutOfRangeException("option") // "_" represents the default
        }}}"
            }
         }
        }
        """;

        Console.WriteLine(multiLineInterpolation);
    }

    public static void PatternMatchingExample()
    {
        var name = "Lewis";
        if (name is [var first, _, .. var rest])
        {
            Console.WriteLine($"First Letter {first}");
            Console.WriteLine($"rest after second letter {rest}");
        }
    }

    public static void RecordExample()
    {
        Person p1 = new("Lewis", "Doe");
        // nondestructive mutation, creates a new object with modified properties. Since we are 
        // working with an immutable type.
        Person p2 = p1 with { LastName = "McKaig" };

        Console.WriteLine(p1.FirstName);
        Console.WriteLine(p2.LastName);
    }

    public record Person(string FirstName, string LastName)
    {
        //compiler will auto generate the constructors and read only properties for us
    }
}