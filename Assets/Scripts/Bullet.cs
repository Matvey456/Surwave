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

    private void FixedUpdate() => BulletDirection(speed, _rb);

    public void BulletDirection(float speed, Rigidbody2D rigidbody2D)
    {
        _direction = transform.right;
        rigidbody2D.velocity = _direction * speed;
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
