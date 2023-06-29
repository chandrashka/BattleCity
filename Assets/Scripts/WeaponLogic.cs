using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    private const float FireTimeDelay = 1f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject firePlace;
    private float _currentFireTimeDelay;

    private void Update()
    {
        if (_currentFireTimeDelay > 0) _currentFireTimeDelay -= Time.deltaTime;
    }

    public void Fire()
    {
        if (_currentFireTimeDelay <= 0)
        {
            var position = firePlace.transform.position;
            var rotation = firePlace.transform.rotation;

            Instantiate(bulletPrefab, position, rotation);
            _currentFireTimeDelay = FireTimeDelay;
        }
    }
}