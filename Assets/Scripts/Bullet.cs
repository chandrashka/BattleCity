using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const int Speed = 7;

    private void Update()
    {
        transform.Translate(Vector3.up * (Speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
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
            if (other.gameObject.TryGetComponent(out EnemyAI _)) ScoreManager.UpdateScore();
        }

        Destroy(gameObject);
    }
}