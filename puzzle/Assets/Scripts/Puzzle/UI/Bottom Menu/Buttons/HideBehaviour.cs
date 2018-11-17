using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.UI.BottomMenu.Buttons
{
    [AddComponentMenu("Puzzle/UI/Bottom Menu/Buttons/Hide")]
    public class HideBehaviour : MonoBehaviour, IClickable
    {
        [SerializeField] private Animator bottomMenuAnimator;
        [SerializeField] private Image arrowRenderer;
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
            arrowRenderer.sprite = rightArrow;
        }

        public void OnHideAnimationEnd()
        {
            arrowRenderer.sprite = leftArrow;
        }
    }
}
