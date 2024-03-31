using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 _direction;
    private Vector3 _size;

    private float _currentDistance;
    
    [SerializeField] private GameObject target;
    
    [SerializeField] private float speed;
    [SerializeField] private float distance;

    private void Start()
    {
        _size = transform.localScale;
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
        transform.localScale = transform.position.x < target.transform.position.x ? _size : new Vector3(-1, 1, 1);
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
