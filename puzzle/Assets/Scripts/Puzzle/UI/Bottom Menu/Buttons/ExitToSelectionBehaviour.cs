using System;
using UnityEngine;
using Service;

namespace Puzzle.UI.BottomMenu.Buttons
{
    [AddComponentMenu("Puzzle/UI/Bottom Menu/Buttons/Exit To Selection")]
    public class ExitToSelectionBehaviour : MonoBehaviour, IClickable
    {
        [SerializeField] private CanvasGroup gamePanel;
        [SerializeField] private CanvasGroup selectionPanel;
        [SerializeField] private float fadeTime;

        public Action ExitingGamePanel;

        public void OnClick()
        {
            StartCoroutine(FadeCoroutines.FadeOut(gamePanel, fadeTime));
            StartCoroutine(FadeCoroutines.FadeIn(selectionPanel, fadeTime));
            ExitingGamePanel.SafeInvoke();
        }
    }
}
