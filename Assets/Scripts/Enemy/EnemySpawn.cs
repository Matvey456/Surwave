using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private AudioSource spawnSound;
    [SerializeField] private TMP_Text waveCountText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private GameUI gameUI;

    [SerializeField] private int timerToSpawn;

    private int _waveCount;
    private int _timer;
    private int _randomPoint;
    
    public GameObject[] points;
    
    private void Start()
    {
        waveCountText.text = $"Wave: {_waveCount}/{StaticHolder.waveCount}".ToString();
        _timer = timerToSpawn;
        timerText.text = $"Next wave: {_timer.ToString()}";

        StartCoroutine(nameof(Timer));
    }

    private void Update() => CheckWave();

    private void CheckWave()
    {
        if (_waveCount == StaticHolder.waveCount + 1)
        {
            gameUI.winAndLoseText.text = "You win";
            gameUI.WinMenuAnimate(0, 1);
            Invoke("StopTime", 1);
        }
    }
    
    private void StopTime()
    {
        Time.timeScale = 0;
    }
    
    private IEnumerator Timer()
    {
        while (true)
        {
            _timer--;
            timerText.text = $"Next wave: {_timer.ToString()}";
            waveCountText.text = $"Wave: {_waveCount}/{StaticHolder.waveCount}".ToString();

            if (_timer == 0)
            {
                _timer = timerToSpawn;
                StartCoroutine(nameof(Spawner));
                spawnSound.Play();
                _waveCount++;
            }
            
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator Spawner()
    {
        for (int i = 0; i < points.Length; i++)
        { 
            _randomPoint = UnityEngine.Random.Range(0, points.Length);
            
            Instantiate(enemyPrefab, points[_randomPoint].transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(1f);
    }
}