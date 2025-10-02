using System;
using System.Collections.Generic;

public class Maze
{
    private int[,] _maze;
    private List<string> _results = new List<string>();

    public Maze(int[,] maze)
    {
        _maze = maze;
    }

    public List<string> SolveMaze(int x, int y, List<(int, int)> currPath)
    {
        // Base case: if we've reached the end (value == 2), add path to results
        if (IsEnd(x, y))
        {
            _results.Add(FormatPath(currPath));
            return _results;
        }

        // If current position is valid, move
        if (IsValidMove(x, y))
        {
            currPath.Add((x, y)); // Add the current position to path

            // Mark the current spot as visited by setting it to 0 (wall)
            _maze[x, y] = 0;

            // Recursive calls for the four possible moves
            SolveMaze(x + 1, y, new List<(int, int)>(currPath)); // Move Down
            SolveMaze(x - 1, y, new List<(int, int)>(currPath)); // Move Up
            SolveMaze(x, y + 1, new List<(int, int)>(currPath)); // Move Right
            SolveMaze(x, y - 1, new List<(int, int)>(currPath)); // Move Left

            // Backtrack by resetting the visited position
            _maze[x, y] = 1;
        }
        return _results;
    }

    public bool IsEnd(int x, int y)
    {
        return _maze[x, y] == 2; // 2 represents the end point in the maze
    }

    public bool IsValidMove(int x, int y)
    {
        return x >= 0 && y >= 0 && x < _maze.GetLength(0) && y < _maze.GetLength(1) && _maze[x, y] != 0;
    }

    private string FormatPath(List<(int, int)> path)
    {
        return string.Join(" -> ", path);
    }
}
