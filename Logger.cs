namespace P1_Hra
{
    public static class Logger
    {
        static readonly ConsoleColor defaultColor = Console.ForegroundColor;
        public static void Log(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = defaultColor;
        }
        public static void Log(string message)
        {
            Console.Write(message);
        }
    }
}