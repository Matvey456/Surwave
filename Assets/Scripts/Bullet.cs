using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D _rb;
    private Vector2 _direction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() => BulletDirection();

    private void BulletDirection()
    {
        _direction = transform.right;
        _rb.velocity = _direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            Destroy(other.gameObject, 1);
            Destroy(gameObject);
        }
    }
}
