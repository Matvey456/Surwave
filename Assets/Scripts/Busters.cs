using System.Collections;
using UnityEngine;

public class Busters : MonoBehaviour
{
    [SerializeField] private GameObject healthPrefab;
    [Range(10, 30), SerializeField] private int timeToSpawn;
    
    private Vector2 _spawn;

    private void Start()
    {
        if (!StaticHolder.isExtremeMode)
        {
            StartCoroutine(nameof(SpawnBuster));
        }
    }

    private IEnumerator SpawnBuster()
    {
        while (true)
        {
            if (StaticHolder.lives < 80)
            {
                _spawn = new Vector2(Random.Range(-7, 7), Random.Range(3, 1));
                Instantiate(healthPrefab, _spawn, Quaternion.identity);
            }
        
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
