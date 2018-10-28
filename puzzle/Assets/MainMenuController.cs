using System;
using UnityEngine;
using System.Collections;
using Puzzle.Game;
using Service;

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

        public Action EnteringGameMode;
        public Action ExitingGameMode;

        private const float TIME_TO_FAID_IN = 0.5f;
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

        public void ExitGameMode()
        {
            StartCoroutine(FadeOutGameMode());
            ExitingGameMode.SafeInvoke();
        }

        // Обработчики кнопок на панели imageSelection
        public void PlayWithAvatar()
        {
            tileController.PrepareGameField(avatarSlices);
            StartCoroutine(FadeInGameMode());
            EnteringGameMode.SafeInvoke();
        }

        public void PlayWithDawkins()
        {
            tileController.PrepareGameField(dawkinsSlices);
            StartCoroutine(FadeInGameMode());
            EnteringGameMode.SafeInvoke();
        }

        public void PlayWithHello()
        {
            tileController.PrepareGameField(helloSlices);
            StartCoroutine(FadeInGameMode());
            EnteringGameMode.SafeInvoke();
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
            currentTime = 0;
        }

        IEnumerator FadeOutGameMode()
        {
            gameModeCanvasGroup.blocksRaycasts = false;

            while (gameModeCanvasGroup.alpha != 0)
            {
                currentTime += Time.deltaTime;
                gameModeCanvasGroup.alpha = Mathf.Lerp(1, 0, currentTime / TIME_TO_FAID_IN);
                yield return null;
            }

            selectionModeCanvasGroup.blocksRaycasts = true;
            currentTime = 0;
        }
    }
}