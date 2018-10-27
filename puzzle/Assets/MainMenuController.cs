using UnityEngine;
using System.Collections;
using Puzzle.Game;

namespace Puzzle.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject gameModePanel;
        [SerializeField] private GameObject collectionPanel;
        [SerializeField] private GameObject optionsPanel;

        [SerializeField] private GameObject selectionModeClickBlocker;
        [SerializeField] private GameObject gameModeClickBlocker;

        [SerializeField] private TileController tileController;

        [SerializeField] private CanvasGroup selectionModeCanvasGroup;
        [SerializeField] private CanvasGroup gameModeCanvasGroup;

        [SerializeField] private Sprite[] avatarSlices;
        [SerializeField] private Sprite[] dawkinsSlices;
        [SerializeField] private Sprite[] helloSlices;

        private const float TIME_TO_FAID_IN = 1;
        private float currentTime = 0;


        // Обработчики кнопок на нижней выдвигающейся панельке.
        public void OpenCollection()
        {
            collectionPanel.SetActive(true);
        }

        public void OpenOptions()
        {
            optionsPanel.SetActive(true);
        }

        public void ExitGame()
        {
            
        }

        // Обработчики кнопок на панели imageSelection
        public void PlayWithAvatar()
        {
            tileController.PrepareGameField(avatarSlices);
            StartCoroutine(FadeInGameMode());
        }

        public void PlayWithDawkins()
        {
            tileController.PrepareGameField(dawkinsSlices);
            StartCoroutine(FadeInGameMode());
        }

        public void PlayWithHello()
        {
            tileController.PrepareGameField(helloSlices);
            StartCoroutine(FadeInGameMode());
        }

        // Обработчики кнопок на панели "Options"
        public void CloseOptions()
        {

        }

        IEnumerator FadeInGameMode()
        {
            selectionModeCanvasGroup.blocksRaycasts = false;

            while (gameModeCanvasGroup.alpha != 1)
            {
                currentTime += Time.deltaTime;
                gameModeCanvasGroup.alpha = Mathf.Lerp(0, 1, currentTime / TIME_TO_FAID_IN);
                yield return null;
            }

            gameModeCanvasGroup.blocksRaycasts = true;
            yield break;
        }
    }
}