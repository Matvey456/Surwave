using System;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Enemy enemy;

    [SerializeField] private GameObject target;
    [SerializeField] private float speed;

    private Vector2 _direction;
    private Rigidbody2D _rb;
    
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() => BulletUpdateDirection();
    
    private void FixedUpdate() => bullet.BulletDirection(speed, _rb);
    
    private void BulletUpdateDirection() => _direction = (target.transform.position - transform.position).normalized;
}
