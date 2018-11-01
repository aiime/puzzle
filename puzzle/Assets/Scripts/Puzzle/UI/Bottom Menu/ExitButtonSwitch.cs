using System.Collections;
using UnityEngine;

namespace Puzzle.UI.BottomMenu
{
    /// <summary>
    /// Кнопки "Выйти в меню выбора" и "Выйти в систему" располагаются на одном и том же месте нижней панели,
    /// прямо друг на друге. А этот скрипт и определяет, какая из этих кнопок сейчас должна отображаться.
    /// Вешается на одну из этих кнопок.
    /// </summary>
    [AddComponentMenu("Puzzle/UI/Bottom Menu/Exit Button Switch")]
    public class ExitButtonSwitch : MonoBehaviour
    {
        [SerializeField] private MainMenuController mainMenuController;
        [SerializeField] private CanvasGroup canvasGroupOfExitToSystemButton;
        [SerializeField] private CanvasGroup canvasGroupOfExitToSelectionButton;
        [SerializeField] private float timeToFade;

        private void Start()
        {
            mainMenuController.EnteringGameMode += delegate
            {
                StartCoroutine(FadeIn_ExitToSelectionButton());
                StartCoroutine(FadeOut_ExitToSystemButton());
            };

            mainMenuController.ExitingGameMode += delegate
            {
                StartCoroutine(FadeIn_ExitToSystemButton());
                StartCoroutine(FadeOut_ExitToSelectionButton());
            };
        }

        private IEnumerator FadeIn_ExitToSelectionButton()
        {
            float currentTime = 0;

            while (canvasGroupOfExitToSelectionButton.alpha != 1)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfExitToSelectionButton.alpha = Mathf.Lerp(0, 1, currentTime / timeToFade);
                yield return null;
            }

            canvasGroupOfExitToSelectionButton.blocksRaycasts = true;
        }

        private IEnumerator FadeOut_ExitToSystemButton()
        {
            canvasGroupOfExitToSystemButton.blocksRaycasts = false;

            float currentTime = 0;

            while (canvasGroupOfExitToSystemButton.alpha != 0)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfExitToSystemButton.alpha = Mathf.Lerp(1, 0, currentTime / timeToFade);
                yield return null;
            }
        }

        private IEnumerator FadeIn_ExitToSystemButton()
        {
            float currentTime = 0;

            while (canvasGroupOfExitToSystemButton.alpha != 1)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfExitToSystemButton.alpha = Mathf.Lerp(0, 1, currentTime / timeToFade);
                yield return null;
            }

            canvasGroupOfExitToSystemButton.blocksRaycasts = true;
        }

        private IEnumerator FadeOut_ExitToSelectionButton()
        {
            canvasGroupOfExitToSelectionButton.blocksRaycasts = false;

            float currentTime = 0;

            while (canvasGroupOfExitToSelectionButton.alpha != 0)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfExitToSelectionButton.alpha = Mathf.Lerp(1, 0, currentTime / timeToFade);
                yield return null;
            }
        }
    }
}
