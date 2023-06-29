using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;
    
    [SerializeField] private int enemiesToSpawn = 12;
    private int _enemiesSpawned;
    private int _killedEnemies;
    
    private float _currentTimeTiNextEnemy;
    [SerializeField] private float timeToNextEnemy;
    
    private void Update()
    {
        if (_currentTimeTiNextEnemy <= 0 && GameManager.IsGameOn && _enemiesSpawned <= enemiesToSpawn)
        {
            enemySpawner.CreateEnemy();
            _currentTimeTiNextEnemy = timeToNextEnemy;
            _enemiesSpawned++;
        }
        else
        {
            _currentTimeTiNextEnemy -= Time.deltaTime;
        }
    }
    
    public bool AllEnemiesKilled()
    {
        return _killedEnemies == enemiesToSpawn;
    }

    public void UpdateEnemies()
    {
        _killedEnemies++;
    }
}
