using System;

namespace AstroLauncher.Utils;

public static class DebugUtil
{
    public static void Error(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}