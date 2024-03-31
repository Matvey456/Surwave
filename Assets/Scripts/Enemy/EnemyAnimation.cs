using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    
    public Animator _anim;

    private void Start() => _anim = GetComponent<Animator>();

    private void Update()
    {
        Run();
        Shoot();
    }
    
    private void Run() => _anim.SetFloat("Speed", enemy.rb.velocity.magnitude > 0 ? 1 : 0);

    private void Shoot() => _anim.SetBool("Shoot", enemy.GetDistance());
}
