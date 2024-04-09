using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private PlayerShoot playerShoot;
    
    [SerializeField] private Animator animateUI;
    
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private GameObject winMenu;
    public TMP_Text winAndLoseText;

    private void Update() => GunIconIdle();
    
    public void LoseMenuAnimate(float endValue, float speed)
    {
        loseMenu.transform.DOMoveY(endValue, speed);
    }
    
    public void WinMenuAnimate(float endValue, float speed)
    {
        winMenu.transform.DOMoveY(endValue, speed);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StaticHolder.lives = StaticHolder.isExtremeMode == false ? 100 : 1;
        Time.timeScale = 1;
    }
    
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void GunIconIdle() => animateUI.SetBool("Reload", playerShoot.Reload());
}
