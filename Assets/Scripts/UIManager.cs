using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenuCanvas;
    [SerializeField] private GameObject endGameCanvas;
    [SerializeField] private GameObject leftTab;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private EnemySpawner scoreManager;

    [SerializeField] private GameObject[] healthHearts;
    [SerializeField] private List<GameObject> enemies;
    
    public void StartMenuUI()
    {
        startMenuCanvas.SetActive(true);
        leftTab.SetActive(false);
        endGameCanvas.SetActive(false);
    }

    public void StartGameUI()
    {
        startMenuCanvas.SetActive(false);
        leftTab.SetActive(true);
        endGameCanvas.SetActive(false);
    }
    public void EndGameUI()
    {
        leftTab.SetActive(false);
        endGameCanvas.SetActive(true);
        var score = 0;
        var text = $"Your score : {score}" ;
        scoreText.text = text;
    }

    public void UpdateHealth(int health)
    {
        if (health is 0 or 1 or 2)
        {
            healthHearts[health].SetActive(false);
        }

        if (health >= 3)
        {
            foreach (var heart in healthHearts)
            {
                heart.SetActive(true);
            }
        }
        
    }
    public void UpdateEnemies(int enemyCounter)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].SetActive(i < enemyCounter-1);
        }
        
        
    }
}
