using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private Enemy enemy;
    
    private Animator _anim;

    private void Start() => _anim = GetComponent<Animator>();

    private void Update()
    {
        Run();
        Shoot();
    }

    private void Run() => _anim.SetFloat("Speed", enemy.rb.velocity.magnitude > 0 ? 1 : 0);
    
    private void Shoot() => _anim.SetBool("Shoot", enemy.GetDistance());

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Bullet"))
        {
            StaticHolder.enemyDeath++;
            Debug.Log($"Всего врагов убито: {StaticHolder.enemyDeath}");
            
            if (!deathSound.isPlaying)
            {
                deathSound.Play();
            }
            
            _anim.SetTrigger("Death");
        }
    }
}
