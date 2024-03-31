using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject mainMenu;
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void SettingsGame()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
