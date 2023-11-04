using System;
using System.Runtime.CompilerServices;

public static class LogHelper
{
    public static string Method([CallerMemberName] string caller = "")
    {
        return caller;
    }
}