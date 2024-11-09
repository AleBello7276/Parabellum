public static class Logger
{

    static int logs = 0;
    static int warnings = 0;
    static int errors = 0;

    public static void Log(string message)
    {   
        // just logs a message with D (Default)
        logs++;
        Console.WriteLine("D --> " + message);
    }

    // Prints Warning Message
    public static void Warning(string message)
    {   
        logs++;
        warnings++;
        Console.WriteLine("W --> " + message);
    }

    // Prints Error Message
    public static void Error(string message)
    {   
        logs++;
        errors++;
        Console.WriteLine("ERR --> " + message);
    }
}