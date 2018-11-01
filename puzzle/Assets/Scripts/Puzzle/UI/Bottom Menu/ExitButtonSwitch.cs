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
    public class Switch_ExitButton : MonoBehaviour
    {
        [SerializeField] private MainMenuController controller_mainMenu;
        [SerializeField] private CanvasGroup canvasGroupOfButton_exitToSystem;
        [SerializeField] private CanvasGroup canvasGroupOfButton_exitToSelection;
        [SerializeField] private float timeToFade;    

        private void Start()
        {
            controller_mainMenu.EnteringGameMode += delegate
            {
                StartCoroutine(FadeInButton_ExitToSelection());
                StartCoroutine(FadeOutButton_ExitToSystem());
            };

            controller_mainMenu.ExitingGameMode += delegate
            {
                StartCoroutine(FadeInButton_ExitToSystem());
                StartCoroutine(FadeOutButton_ExitToSelection());
            };
        }

        private IEnumerator FadeInButton_ExitToSelection()
        {
            float currentTime = 0;

            while (canvasGroupOfButton_exitToSelection.alpha != 1)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfButton_exitToSelection.alpha = Mathf.Lerp(0, 1, currentTime / timeToFade);
                yield return null;
            }

            canvasGroupOfButton_exitToSelection.blocksRaycasts = true;
        }

        private IEnumerator FadeOutButton_ExitToSystem()
        {
            canvasGroupOfButton_exitToSystem.blocksRaycasts = false;

            float currentTime = 0;

            while (canvasGroupOfButton_exitToSystem.alpha != 0)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfButton_exitToSystem.alpha = Mathf.Lerp(1, 0, currentTime / timeToFade);
                yield return null;
            }
        }

        private IEnumerator FadeInButton_ExitToSystem()
        {
            float currentTime = 0;

            while (canvasGroupOfButton_exitToSystem.alpha != 1)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfButton_exitToSystem.alpha = Mathf.Lerp(0, 1, currentTime / timeToFade);
                yield return null;
            }

            canvasGroupOfButton_exitToSystem.blocksRaycasts = true;
        }

        private IEnumerator FadeOutButton_ExitToSelection()
        {
            canvasGroupOfButton_exitToSelection.blocksRaycasts = false;

            float currentTime = 0;

            while (canvasGroupOfButton_exitToSelection.alpha != 0)
            {
                currentTime += Time.deltaTime;
                canvasGroupOfButton_exitToSelection.alpha = Mathf.Lerp(1, 0, currentTime / timeToFade);
                yield return null;
            }
        }
    }
}
