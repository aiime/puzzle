using UnityEngine;

namespace Puzzle.UI.OptionsMenu.Buttons
{
    [AddComponentMenu("Puzzle/UI/Options Menu/Buttons/Refuse")]
    public class RefuseBehaviour : MonoBehaviour, IClickable
    {
        [SerializeField] private CanvasGroup optionsPanel;
        [SerializeField] private float fadeTime;

        public void OnClick()
        {
            StartCoroutine(FadeCoroutines.FadeOut(optionsPanel, fadeTime));
        }
    }
}
