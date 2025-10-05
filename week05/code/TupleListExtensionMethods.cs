using System.Collections.Generic;
using System.Text;

public static class PathExtensions
{
    public static string AsString(this List<(int, int)> path)
    {
        if (path == null || path.Count == 0) return string.Empty;

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < path.Count; i++)
        {
            sb.Append($"({path[i].Item1},{path[i].Item2})");
            if (i != path.Count - 1) sb.Append(" -> ");
        }
        return sb.ToString();
    }
}
