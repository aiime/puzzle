using UnityEngine;

namespace Puzzle.UI.BottomMenu
{
    [AddComponentMenu("Puzzle/UI/Bottom Menu/Options Button Controller")]
    public class OptionsButtonController : MonoBehaviour, IClickable
    {
        [SerializeField] private CanvasGroup optionsPanel;
        [SerializeField] private float fadeTime;

        public void OnClick()
        {
            StartCoroutine(FadeCoroutines.FadeIn(optionsPanel, fadeTime));
        }
    }
}
