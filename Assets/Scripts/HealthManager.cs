using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public int health;
    public bool isEnemy;
    
    public void UpdateHealth(int update)
    {
        health += update;

        switch (health)
        {
            case <= 0 when isEnemy:
                Destroy(gameObject);
                break;
            case <= 0 when !isEnemy:
                gameManager.UpdateHealth(health);
                GameManager.IsGameOn = false;
                break;
            case > 0 when !isEnemy:
                //gameManager.ReSpawnPlayer();
                gameManager.UpdateHealth(health);
                break;
        }
    }
}
