using System;
using System.Collections.Generic;

public static class TupleListExtensionMethod
{
    public static string AsString(this List<(int, int)> path)
    {
        return string.Join(" -> ", path);
    }
}
