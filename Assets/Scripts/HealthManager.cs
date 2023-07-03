using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private GameManager _gameManager;
    public int health;
    public bool isEnemy;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void UpdateHealth(int update)
    {
        health += update;

        switch (health)
        {
            case <= 0 when isEnemy:
                Destroy(gameObject);
                break;
            case <= 0 when !isEnemy:
                _gameManager.UpdateHealth(health);
                _gameManager.EndGame();
                break;
            case > 0 when !isEnemy:
                //gameManager.ReSpawnPlayer();
                _gameManager.UpdateHealth(health);
                break;
        }
    }
}