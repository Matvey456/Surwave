using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource stepsSound;
    
    private Rigidbody2D _rb;
    private Vector2 _direction;

    private float _horizontalMove;
    private float _vertcalMove;
    
    [SerializeField] public float speed;
    
    private void Start() => _rb = GetComponent<Rigidbody2D>();

    private void FixedUpdate() => Move();

    private void Update() => Flip();
    
    private void Flip()
    {
        if (_rb.velocity.x > 0.15) 
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (_rb.velocity.x < -0.15)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    
    private void Move()
    {
        _horizontalMove = Input.GetAxis("Horizontal");
        _vertcalMove = Input.GetAxis("Vertical");
        
        _direction = new Vector2(_horizontalMove, _vertcalMove);
        _rb.velocity = _direction * speed;

        if (_rb.velocity.x != 0)
        {
            stepsSound.Play();
        }
        else
        {
            stepsSound.Stop();
        }
    }
}
