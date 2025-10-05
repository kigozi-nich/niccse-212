using System.Collections.Generic;

public class Maze
{
    private int[,] _maze;

    public Maze(int[,] maze)
    {
        _maze = (int[,])maze.Clone(); // Create a copy to avoid modifying the original
    }

    public List<string> SolveMaze(int x, int y, List<(int, int)> path)
    {
        List<string> results = new List<string>();
        List<(int, int)> currentPath = new List<(int, int)>(path);
        SolveMazeRecursive(x, y, currentPath, results);
        return results;
    }

    private void SolveMazeRecursive(int x, int y, List<(int, int)> path, List<string> results)
    {
        if (!IsValidMove(x, y)) return;

        path.Add((x, y));

        if (IsEnd(x, y))
        {
            results.Add(path.AsString());
            return;
        }

        int temp = _maze[x, y];
        _maze[x, y] = 0; // mark visited

        // Try all four directions with new path copies
        SolveMazeRecursive(x + 1, y, new List<(int, int)>(path), results);
        SolveMazeRecursive(x - 1, y, new List<(int, int)>(path), results);
        SolveMazeRecursive(x, y + 1, new List<(int, int)>(path), results);
        SolveMazeRecursive(x, y - 1, new List<(int, int)>(path), results);

        _maze[x, y] = temp; // backtrack
    }

    public bool IsValidMove(int x, int y)
    {
        return x >= 0 && y >= 0 && x < _maze.GetLength(0) && y < _maze.GetLength(1) && _maze[x, y] != 0;
    }

    public bool IsEnd(int x, int y)
    {
        return x >= 0 && y >= 0 && x < _maze.GetLength(0) && y < _maze.GetLength(1) && _maze[x, y] == 2;
    }
}
