using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float speed;

    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() => bullet.BulletDirection(speed, _rb);
}
