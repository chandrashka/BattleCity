using UnityEngine;

public class Bullet : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private EnemyManager _enemyManager;
    private const int Speed = 7;

    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _enemyManager = FindObjectOfType<EnemyManager>();
    }

    private void Update()
    {
        transform.Translate(Vector3.up * (Speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        if (other.gameObject.TryGetComponent(out WallLogic _))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.TryGetComponent(out PlayerBaseLogic _))
        {
            Destroy(other.gameObject);
            GameManager.IsGameOn = false;
        }
        else if (other.gameObject.TryGetComponent(out HealthManager healthManagerComponent))
        {
            healthManagerComponent.UpdateHealth(-1);
            if (other.gameObject.TryGetComponent(out EnemyAI _))
            {
                _scoreManager.UpdateScore();
                _enemyManager.UpdateEnemies();
            }
        }
    }
}