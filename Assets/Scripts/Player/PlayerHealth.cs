using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private int damageToPlayer;

    [SerializeField] private GameUI gameUI;

    private void Start()
    {
        healthBar.maxValue = StaticHolder.lives;
        healthBar.value = StaticHolder.lives;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("EnemyBullet"))
        {
            Damage(damageToPlayer);
            if (healthBar.value == 0)
            {
                gameUI.winAndLoseText.text = "You lose";
                gameUI.LoseMenuAnimate(0, 1);
                Invoke("StopTime", 1);
            }
        }

        if (other.transform.CompareTag("Health"))
        {
            healthBar.value = StaticHolder.lives;
        }
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }

    public void Damage(int damage)
    {
        StaticHolder.lives -= damage;
        healthBar.value = StaticHolder.lives;
    }
}
