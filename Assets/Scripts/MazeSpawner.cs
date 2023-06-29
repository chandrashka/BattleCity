using Unity.VisualScripting;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cell;
    [SerializeField] private GameObject nonDestroyableCell;
    
    [SerializeField] private GameObject playerBasePrefab;
    [SerializeField] private GameObject spawnPlacePrefab;
    
    public GameObject spawnPlace;
    public GameObject playerBase;
    private const int WallsAroundToDelete = 4;
    private Cell[,] _walls;

    public void SpawnMaze()
    {
        const int startPointX = -10;
        const int startPointY = -5;
        
        var generator = new MazeGenerator();
        var maze = generator.GenerateMaze();
        
        _walls = new Cell[maze.GetLength(0),maze.GetLength(1)];
        var baseIndexI = 0;
        var baseIndexJ = 0;

        for (var i = 0; i < maze.GetLength(0); i++)
        {
            for (var j = 0; j < maze.GetLength(1); j++)
            {
                if (i == maze.GetLength(0)/2 && j == 1)
                {
                    playerBase = Instantiate(playerBasePrefab, new Vector3(i + startPointX, j + startPointY),
                        Quaternion.identity);

                    baseIndexI = i;
                    baseIndexJ = j;

                    spawnPlace = Instantiate(spawnPlacePrefab,new Vector3( i - 1 + startPointX, j + startPointY),
                        Quaternion.identity);
                }
                else
                {
                    var random = new System.Random();
                    Cell c;
                    if (random.Next(0,25) == 0) {
                        c = Instantiate(nonDestroyableCell, new Vector2(i + startPointX,j + startPointY),
                        Quaternion.identity).GetComponent<Cell>();
                        
                    }
                    else
                    {
                        c = Instantiate(cell, new Vector2(i + startPointX,j + startPointY),
                            Quaternion.identity).GetComponent<Cell>();
                    }

                    _walls[i,j] = c;

                    HideWalls(c, maze[i,j].WallLeft, maze[i,j].WallBottom);
                }
            }
        }
        DeleteWallsAroundBase(baseIndexI,baseIndexJ,maze,_walls);
        DeleteExtraWalls(maze, _walls);
    }

    private void DeleteExtraWalls(MazeCellGenerator[,] maze, Cell[,] walls)
    {
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            var c = walls[i, maze.GetLength(1) - 1];
                if (c != null)
                {
                    Destroy(c.GameObject());
                }
        }
    }

    private static void DeleteWallsAroundBase(int x, int y, MazeCellGenerator[,] maze, Cell[,] walls)
    {
        var width = maze.GetLength(0);
        var height = maze.GetLength(1);
        for (var i = x - WallsAroundToDelete; i < x + WallsAroundToDelete; i++)
        {
            for (var j = y - WallsAroundToDelete; j < y + WallsAroundToDelete; j++)
            {
                if (i >= 0 && i < width && j >= 0 && j < height)
                {
                    var c = walls[i, j];
                    if (c != null)
                    {
                        Destroy(c.GameObject());
                    }
                }
            }
        }
    }

    private static void HideWalls(Cell c, bool hideWallLeft, bool hideWallBottom)
    {
        c.wallLeft.SetActive(hideWallLeft);
        c.wallBottom.SetActive(hideWallBottom);
    }

    public void DeleteMaze()
    {
        foreach (var c in _walls)
        {
            if(c != null) Destroy(c.GameObject());
        }
        Destroy(playerBase);
        Destroy(spawnPlace);
    }
}