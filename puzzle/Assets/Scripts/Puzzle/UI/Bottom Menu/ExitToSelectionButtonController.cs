using System;
using System.Collections;

using UnityEngine;

using Service;

namespace Puzzle.UI.BottomMenu
{
    [AddComponentMenu("Puzzle/UI/Bottom Menu/Exit To Selection Button Controller")]
    public class ExitToSelectionButtonController : MonoBehaviour, IClickable
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
