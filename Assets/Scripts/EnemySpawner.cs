using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    private const int MinX = -4;
    private const int MaxX = 6;
    private const float Y = 4.4f;

    [SerializeField] private GameObject enemyPrefab;

    private Random _random;

    private void Start()
    {
        _random = new Random();
    }

    private Vector3 CalculatePositionOfNewEnemy()
    {
        return new Vector3(_random.Next(MinX, MaxX), Y);
    }
    
    public void CreateEnemy()
    {
        Instantiate(enemyPrefab, CalculatePositionOfNewEnemy(), Quaternion.identity);
    }
}