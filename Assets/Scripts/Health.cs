using UnityEngine;

public class Health : MonoBehaviour
{
    private int _randomHealth;
    
    private void Start()
    {
        _randomHealth = UnityEngine.Random.Range(10, 30);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StaticHolder.lives += _randomHealth;
            Destroy(gameObject);
        }
    }
}
