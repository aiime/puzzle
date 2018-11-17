using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.UI.GameMenu.Buttons
{
    [AddComponentMenu("Puzzle/UI/Game Menu/Buttons/Confirm")]
    public class ConfirmBehaviour : MonoBehaviour, IClickable
    {
        [SerializeField] private CanvasGroup gamePanel;
        [SerializeField] private CanvasGroup selectionPanel;
        [SerializeField] private CanvasGroup exitToSystemButton;
        [SerializeField] private CanvasGroup exitToSelectionButton;
        [SerializeField] private CanvasGroup confirmButton;
        [SerializeField] private StretchyGridLayoutGroup tilesGrid;
        [SerializeField] private float fadeTime;

        private Vector2 defaultTilesSpacing;

        private void Start()
        {
            defaultTilesSpacing = tilesGrid.spacing;
        }

        public void OnClick()
        {
            StartCoroutine(FadeCoroutines.FadeOut(confirmButton, fadeTime));
            StartCoroutine(FadeCoroutines.FadeOut(gamePanel, fadeTime, SetDefaultTilesSpacing));
            StartCoroutine(FadeCoroutines.FadeOut(exitToSelectionButton, fadeTime));
            StartCoroutine(FadeCoroutines.FadeIn(selectionPanel, fadeTime));   
            StartCoroutine(FadeCoroutines.FadeIn(exitToSystemButton, fadeTime));
        }

        private void SetDefaultTilesSpacing()
        {
            tilesGrid.spacing = defaultTilesSpacing;
        }
    }
}
