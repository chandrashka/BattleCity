using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MazeSpawner mazeSpawner;
    private static UIManager _uiManager;
    [SerializeField] private GameObject playerPrefab;
    
    private GameObject _player;
    private HealthManager _healthManager;
    public static bool IsGameOn;
    private bool _isGameStart = true;
    
    

    private void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        EnemySpawner.EnemyCount = 12;
        _uiManager.StartMenuUI();
        Screen.SetResolution(800, 600, false);
    }

    private void Update()
    {
        if (!IsGameOn && !_isGameStart || EnemySpawner.EnemyCount <= 0)
        {
            EndGame();
        }
        _uiManager.UpdateEnemies(EnemySpawner.EnemyCount);
    }

    public void StartTheGame()
    {
        IsGameOn = true;
        _isGameStart = false;
        
        _uiManager.StartGameUI();
        mazeSpawner.SpawnMaze();
        
        var spawnPlace = mazeSpawner.spawnPlace;
        SpawnPlayer(spawnPlace);
        
        _healthManager = _player.GetComponent<HealthManager>();
        UpdateHealth(_healthManager.health);
        _uiManager.UpdateEnemies(EnemySpawner.EnemyCount);
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
        _player.transform.Rotate(new Vector3(0,0,90));
    }

    private void EndGame()
    {
        _uiManager.EndGameUI();
    }

    public void UpdateHealth(int health)
    {
        _uiManager.UpdateHealth(health);
    }
    
    
}
