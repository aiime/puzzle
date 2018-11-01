using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.UI.BottomMenu
{
    [AddComponentMenu("Puzzle/UI/Bottom Menu/Hide Button Controller")]
    public class Controller_HideButton : MonoBehaviour
    {
        [SerializeField] private Animator animator_bottomMenu;
        [SerializeField] private Image image_hideButton;
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
            image_hideButton.sprite = rightArrow;
        }

        public void OnHideAnimationEnd()
        {
            image_hideButton.sprite = leftArrow;
        }

        private void HideMenu()
        {
            menuOpened = false;
            animator_bottomMenu.SetTrigger("HideMenu");
        }

        private void OpenMenu()
        {
            menuOpened = true;
            animator_bottomMenu.SetTrigger("OpenMenu");
        }
    }
}
