using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.UI.BottomMenu
{
    [AddComponentMenu("Puzzle/UI/Bottom Menu/Hide Button Controller")]
    public class HideButtonController : MonoBehaviour
    {
        [SerializeField] private Animator bottomMenuAnimator;
        [SerializeField] private Image hideButtonImage;
        [SerializeField] private Sprite rightArrow;
        [SerializeField] private Sprite leftArrow;
        private bool menuOpened;

        public void OnHideButtonClick()
        {
            if (menuOpened)
            {
                HideMenu();
            }
            else
            {
                OpenMenu();
            }
        }

        public void OnOpenAnimationEnd()
        {
            hideButtonImage.sprite = rightArrow;
        }

        public void OnHideAnimationEnd()
        {
            hideButtonImage.sprite = leftArrow;
        }

        private void HideMenu()
        {
            menuOpened = false;
            bottomMenuAnimator.SetTrigger("HideMenu");
        }

        private void OpenMenu()
        {
            menuOpened = true;
            bottomMenuAnimator.SetTrigger("OpenMenu");
        }
    }
}
