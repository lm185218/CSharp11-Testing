//Top level statements mean I can write code in the Program.cs without a surrounding class

using CSharp11;

internal class Program
{
    private static void Main(string[] args)
    {
        /*StringUpdates();*/
        GenericMathSupport.NewMathChanges();
    }

    public static void StringUpdates()
    {
        //--------------------------------------------------------------------------------------------------

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

        //new pattern matching syntax switch statements
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
}