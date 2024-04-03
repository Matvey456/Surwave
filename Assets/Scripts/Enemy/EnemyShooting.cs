using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    
    [SerializeField] private GameObject bulletPrefab;
    private Transform _firePoint;

    private void Start()
    {
        _firePoint = GetComponentInChildren<Transform>();

        StartCoroutine(nameof(Spawn));
    }
    
    private IEnumerator Spawn()
    {
        while (true)
        {
            if (enemy.GetDistance())
            {
                GameObject bullet = Instantiate(bulletPrefab, _firePoint.position, transform.rotation);
                Destroy(bullet, 2);
            }
        
            yield return new WaitForSeconds(1f);
        }
    }
}
