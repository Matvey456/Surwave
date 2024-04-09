using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchMode : MonoBehaviour
{
    [SerializeField] private Toggle easy, extreme;
    [SerializeField] private Button playButton;
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private Slider waveSlider;

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
                StaticHolder.isExtremeMode = false;
                SceneManager.LoadScene(2);
            }

            if (extreme.isOn)
            {
                StaticHolder.isExtremeMode = true;
                SceneManager.LoadScene(2);
            }
        }
    }
    
    public void EasyMode() => StaticHolder.lives = 100;

    public void ExtremeMode() => StaticHolder.lives = 1;

    public void Back() => SceneManager.LoadScene(0);
    
    public void Waves()
    {
        waveText.text = Mathf.Round(waveSlider.value).ToString();
        StaticHolder.waveCount = Mathf.RoundToInt(waveSlider.value);
    }
}
