using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeToNextEnemy;
    public static int EnemyCount = 12;

    private const int MinX = -4;
    private const int MaxX = 6;
    private const float Y = 4.4f;

    private Random _random;
    private float _currentTimeTiNextEnemy;

    private void Start()
    {
        _random = new Random();
    }

    private void Update()
    {
        if (_currentTimeTiNextEnemy <= 0 && GameManager.IsGameOn && EnemyCount > 0)
        {
            Instantiate(enemyPrefab, CalculatePositionOfNewEnemy(), Quaternion.identity);
            _currentTimeTiNextEnemy = timeToNextEnemy;
            EnemyCount--;
        }
        else
        {
            _currentTimeTiNextEnemy -= Time.deltaTime;
        }
    }

    private Vector3 CalculatePositionOfNewEnemy()
    {
        return new Vector3(_random.Next(MinX, MaxX), Y);
    }
}
