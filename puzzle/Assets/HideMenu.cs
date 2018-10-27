using UnityEngine;
using UnityEngine.UI;

public class HideMenu : MonoBehaviour
{
    [SerializeField] private Animator menuAnimator;
    [SerializeField] private Image arrowImage;
    [SerializeField] private Sprite arrowRight;
    [SerializeField] private Sprite arrowLeft;
    private bool menuOpened;

    public void OnHideMenuClick()
    {
        if (menuOpened)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

    public void SetRightArrow()
    {
        arrowImage.sprite = arrowRight;
    }

    public void SetLeftArrow()
    {
        arrowImage.sprite = arrowLeft;
    }

    private void CloseMenu()
    {
        menuOpened = false;
        menuAnimator.SetTrigger("CloseMenu");
    }

    private void OpenMenu()
    {
        menuOpened = true;
        menuAnimator.SetTrigger("OpenMenu");  
    } 
}
