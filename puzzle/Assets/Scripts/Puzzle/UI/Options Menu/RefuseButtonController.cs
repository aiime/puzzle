using UnityEngine;

namespace Puzzle.UI.OptionsMenu
{
    [AddComponentMenu("Puzzle/UI/Options Menu/Refuse Button Controller")]
    public class RefuseButtonController : MonoBehaviour, IClickable
    {
        [SerializeField] private CanvasGroup optionsPanel;
        [SerializeField] private float fadeTime;

        public void OnClick()
        {
            StartCoroutine(FadeCoroutines.FadeOut(optionsPanel, fadeTime));
        }
    }
}
