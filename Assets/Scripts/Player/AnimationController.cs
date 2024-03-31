using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private PlayerShoot playerShoot;
    
    private void Start() => _anim = GetComponent<Animator>();

    private void Update()
    {
        Run();
        CheckShooting();
        CheckReloading();
    }

    private void Run()
    {
        float _axis = Input.GetAxis("Horizontal");
        
        if (_axis != 0)
        {
            if (_axis > 0.01f)
            {
                _anim.SetFloat("Speed", 1);
            }
            else if (_axis < 0.01f)
            {
                _anim.SetFloat("Speed", 1);
            }
        }
        else
        {
            _anim.SetFloat("Speed", 0);
        }
    }

    private void CheckShooting() => _anim.SetBool("Shoot", playerShoot.Shooting());

    private void CheckReloading() => _anim.SetBool("Reload", playerShoot.Reload());
}
