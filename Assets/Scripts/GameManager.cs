using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private MazeSpawner mazeSpawner;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private GameObject playerPrefab;
    private HealthManager _healthManager;
    private bool _isGameStart = true;
    public static bool IsGameOn;

    private GameObject _player;

    private void Start()
    {
        uiManager.StartMenuUI();
        Screen.SetResolution(800, 600, false);
    }

    private void Update()
    {
        if ((!IsGameOn && !_isGameStart) || enemyManager.AllEnemiesKilled()) EndGame();
        uiManager.UpdateEnemies(0);
    }

    public void StartTheGame()
    {
        IsGameOn = true;
        _isGameStart = false;

        uiManager.StartGameUI();
        mazeSpawner.SpawnMaze();

        var spawnPlace = mazeSpawner.spawnPlace;
        SpawnPlayer(spawnPlace);

        _healthManager = _player.GetComponent<HealthManager>();
        UpdateHealth(_healthManager.health);
        uiManager.UpdateEnemies(0);
    }

    public void RestartTheGame()
    {
        IsGameOn = true;

        mazeSpawner.DeleteMaze();
        Destroy(_player);

        StartTheGame();
    }

    private void SpawnPlayer(GameObject spawnPlace)
    {
        var position = spawnPlace.transform.position;

        _player = Instantiate(playerPrefab, position, Quaternion.identity);
        _player.transform.Rotate(new Vector3(0, 0, 90));
    }

    private void EndGame()
    {
        uiManager.EndGameUI(scoreManager.totalScore);
    }

    public void UpdateHealth(int health)
    {
        uiManager.UpdateHealth(health);
    }
}