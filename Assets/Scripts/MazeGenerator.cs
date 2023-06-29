using System;

public class MazeGenerator
{
    private const int Width = 18;
    private const int Height = 10;
    private const int CurrencyToRemoveWall = 6;

    public MazeCellGenerator[,] GenerateMaze()
    {
        var maze = new MazeCellGenerator[Width, Height];

        for (var i = 0; i < maze.GetLength(0); i++)
        for (var j = 0; j < maze.GetLength(1); j++)
            maze[i, j] = new MazeCellGenerator();

        RemoveWalls(maze);

        return maze;
    }

    private void RemoveWalls(MazeCellGenerator[,] maze)
    {
        var random = new Random();

        foreach (var cell in maze)
        {
            cell.WallLeft = random.Next(CurrencyToRemoveWall) == 1;
            cell.WallBottom = random.Next(CurrencyToRemoveWall) == 1;
        }
    }
}