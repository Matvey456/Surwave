using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonAnimate : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private Vector3[] buttonPositions;
    
    [SerializeField] private float speedAnimation;
    [SerializeField] private float delayBetweenAnimations;

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].transform.DOMove(buttonPositions[i], speedAnimation).SetDelay(i * delayBetweenAnimations);
        }
    }

    public void SelectButton(int buttonId)
    {
        buttons[buttonId].transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), .5f);
    }
    
    public void DeselectButton(int buttonId)
    {
        buttons[buttonId].transform.DOScale(new Vector3(1f, 1f, 1f), .5f);
    }
}
