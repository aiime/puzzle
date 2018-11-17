using UnityEngine;
using Puzzle.Game;

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
        [SerializeField] private TilesController tilesController;
        [SerializeField] private CanvasGroup exitToSystemButton;
        [SerializeField] private CanvasGroup exitToSelectionButton;
        [SerializeField] private ExitToSelectionButtonController exitToSelectionButtonController;
        [SerializeField] private float fadeTime;

        private void Start()
        {
            tilesController.EnteringGamePanel += () =>
            {
                StartCoroutine(FadeCoroutines.FadeIn(exitToSelectionButton, fadeTime));
                StartCoroutine(FadeCoroutines.FadeOut(exitToSystemButton, fadeTime));
            };

            exitToSelectionButtonController.ExitingGamePanel += () =>
            {
                StartCoroutine(FadeCoroutines.FadeIn(exitToSystemButton, fadeTime));
                StartCoroutine(FadeCoroutines.FadeOut(exitToSelectionButton, fadeTime));
            };
        }
    }
}
