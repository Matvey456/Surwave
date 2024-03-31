using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] public TMP_Text winAndLoseText;
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
        Time.timeScale = 1;
    }
    
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    

}
