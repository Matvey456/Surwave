using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [Space(10)]
    [SerializeField] private int playerLives = 100;
    [SerializeField] private int damageToPlayer;

    [SerializeField] private GameUI gameUI;

    private void Start()
    {
        healthBar.maxValue = playerLives;
        healthBar.value = playerLives;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            Damage(damageToPlayer);
            if (healthBar.value == 0)
            {
                gameUI.winAndLoseText.text = "You lose";
                gameUI.LoseMenuAnimate(0, 1);
                Invoke("StopTime", 1);
            }
            Debug.Log($"ауч!! {damageToPlayer}");
        }
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }

    private void Damage(int damage)
    {
        playerLives -= damage;
        healthBar.value = playerLives;
    }
}
