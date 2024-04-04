using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchMode : MonoBehaviour
{
    [SerializeField] private Toggle easy, extreme;
    [SerializeField] private Button playButton;

    private bool _difficultySelected = false;

    private void Start() => playButton.interactable = false;

    private void Update() => CheckDifficulty();

    private void CheckDifficulty()
    {
        if (easy.isOn || extreme.isOn)
        {
            _difficultySelected = true;
            playButton.interactable = true;
        }
        else
        {
            _difficultySelected = false;
            playButton.interactable = false;
        }
    }

    public void PlayGame()
    {
        if (_difficultySelected)
        {
            if (easy.isOn)
            {
                SceneManager.LoadScene(2);
            }

            if (extreme.isOn)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
    
    public void EasyMode()
    {
        StaticHolder.lives = 100;
    }
    
    public void ExtremeMode()
    {
        StaticHolder.lives = 1;
    }
    
}
