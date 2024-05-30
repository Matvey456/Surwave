using System.Collections;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class AchievementsManager : MonoBehaviour
{
    [SerializeField] private TMP_Text achievementDescription, achievementTitle;
    [SerializeField] private GameObject achievement;
    [SerializeField] private AudioSource achievementSound;

    [SerializeField] private Vector3 achievementPosition, currentAchievementPosition;
    [SerializeField] private float achievementCooldawn;

    public void AnimateAchievement(string achievementDescription, string achievementTitle)
    {
        this.achievementDescription.text = achievementDescription;
        this.achievementTitle.text = achievementTitle;
        achievement.transform.DOMove(achievementPosition, .5f).SetDelay(.5f);
        achievementSound.Play();
        StartCoroutine(nameof(Back));
    }

    private IEnumerator Back()
    {
        achievement.transform.DOMove(currentAchievementPosition, .5f).SetDelay(achievementCooldawn);
        
        yield return new WaitForSeconds(1);
    }
}
