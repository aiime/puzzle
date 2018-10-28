using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle.MainMenu
{
    public class ExitButtonSwitch : MonoBehaviour
    {
        [SerializeField] private MainMenuController mainMenuController;

        [SerializeField] private CanvasGroup exitToSystemButton;
        [SerializeField] private CanvasGroup exitToSelectionButton;

        private float currentTimeForFadeIn;
        private float currentTimeForFadeOut;
        private const float TIME_TO_FADE = 0.5f;

        private void Start()
        {
            mainMenuController.EnteringGameMode += SwitchOnExitToSelectionModeButton;
            mainMenuController.ExitingGameMode += SwitchOnExitToSystemButton;
        }
        
        private void SwitchOnExitToSelectionModeButton()
        {
            StartCoroutine(ExitToSystemButton_FadeOut());
            StartCoroutine(ExitToSelectionModeButton_FadeIn());
        }

        private void SwitchOnExitToSystemButton()
        {
            StartCoroutine(ExitToSystemButton_FadeIn());
            StartCoroutine(ExitToSelectionModeButton_FadeOut());
        }

        private IEnumerator ExitToSystemButton_FadeOut()
        {
            exitToSystemButton.blocksRaycasts = false;

            while (exitToSystemButton.alpha != 0)
            {
                currentTimeForFadeOut += Time.deltaTime;
                exitToSystemButton.alpha = Mathf.Lerp(1, 0, currentTimeForFadeOut / TIME_TO_FADE);
                yield return null;
            }

            currentTimeForFadeOut = 0;
        }

        private IEnumerator ExitToSelectionModeButton_FadeIn()
        {
            while (exitToSelectionButton.alpha != 1)
            {
                currentTimeForFadeIn += Time.deltaTime;
                exitToSelectionButton.alpha = Mathf.Lerp(0, 1, currentTimeForFadeIn / TIME_TO_FADE);
                yield return null;
            }

            exitToSelectionButton.blocksRaycasts = true;
            currentTimeForFadeIn = 0;
        }

        private IEnumerator ExitToSystemButton_FadeIn()
        {
            while (exitToSystemButton.alpha != 1)
            {
                currentTimeForFadeIn += Time.deltaTime;
                exitToSystemButton.alpha = Mathf.Lerp(0, 1, currentTimeForFadeIn / TIME_TO_FADE);
                yield return null;
            }

            exitToSystemButton.blocksRaycasts = true;
            currentTimeForFadeIn = 0;
        }

        private IEnumerator ExitToSelectionModeButton_FadeOut()
        {
            exitToSelectionButton.blocksRaycasts = false;

            while (exitToSelectionButton.alpha != 0)
            {
                currentTimeForFadeOut += Time.deltaTime;
                exitToSelectionButton.alpha = Mathf.Lerp(1, 0, currentTimeForFadeOut / TIME_TO_FADE);
                yield return null;
            }

            currentTimeForFadeOut = 0;
        }
    }
}
