using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private EnemyAnimation enemyAnimation;
    
    [SerializeField] private GameObject bulletPrefab;
    private Transform _firePoint;

    private void Start()
    {
        _firePoint = GetComponentInChildren<Transform>();
    }

    private void Update()
    {
        if (enemyAnimation.Run())
        {
            Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity);
        }
    }
}
