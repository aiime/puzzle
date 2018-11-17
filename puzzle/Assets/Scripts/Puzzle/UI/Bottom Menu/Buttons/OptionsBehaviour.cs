using UnityEngine;

namespace Puzzle.UI.BottomMenu.Buttons
{
    [AddComponentMenu("Puzzle/UI/Bottom Menu/Buttons/Options")]
    public class OptionsBehaviour : MonoBehaviour, IClickable
    {
        [SerializeField] private CanvasGroup optionsPanel;
        [SerializeField] private float fadeTime;

        public void OnClick()
        {
            StartCoroutine(FadeCoroutines.FadeIn(optionsPanel, fadeTime));
        }
    }
}
