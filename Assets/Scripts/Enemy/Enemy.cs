using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 _direction;

    private float _currentDistance;
    
    [SerializeField] private GameObject target;
    
    [SerializeField] private float speed;
    [SerializeField] private float distance;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate() => Move();

    private void Update() => Flip();

    private void Move()
    {
        _direction = (target.transform.position - transform.position).normalized;

        _currentDistance = Vector2.Distance(target.transform.position, transform.position);
        GetDistance();
    }

    private void Flip()
    {
        if (rb.velocity.x > 0.15) 
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (rb.velocity.x < -0.15)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    public bool GetDistance()
    {
        if (_currentDistance >= distance)
        {
            rb.velocity = _direction * speed;
            return false;
        }
        else
        {
            rb.velocity = Vector2.zero;
            return true;
        }
    }
}
