using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.UI.BottomMenu
{
    [AddComponentMenu("Puzzle/UI/Bottom Menu/Hide Button Controller")]
    public class HideButtonController : MonoBehaviour, IClickable
    {
        [SerializeField] private Animator bottomMenuAnimator;
        [SerializeField] private Image arrowHolder;
        [SerializeField] private Sprite rightArrow;
        [SerializeField] private Sprite leftArrow;

        private bool menuOpened;

        public void OnClick()
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

        // Вызываются из анимаций.
        public void OnOpenAnimationEnd()
        {
            arrowHolder.sprite = rightArrow;
        }

        public void OnHideAnimationEnd()
        {
            arrowHolder.sprite = leftArrow;
        }
    }
}
