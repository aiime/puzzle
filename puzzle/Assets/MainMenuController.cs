using UnityEngine;
using UnityEngine.SceneManagement;

namespace Puzzle.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject newGamePanel;
        [SerializeField] private GameObject optionsPanel;

        [SerializeField] private Sprite[] avatarSlices;
        [SerializeField] private Sprite[] dawkinsSlices;
        [SerializeField] private Sprite[] helloSlices;

        [SerializeField] private string puzzleScene;

        private void Awake()
        {
            //DontDestroyOnLoad(this.gameObject);
        }

        // Обработчики кнопок на панели "Main Menu"
        public void OnNewGameButtonClick()
        {
            mainMenuPanel.SetActive(false);
            newGamePanel.SetActive(true);
            optionsPanel.SetActive(false);
        }

        public void OnOptionsButtonClick()
        {
            mainMenuPanel.SetActive(false);
            newGamePanel.SetActive(false);
            optionsPanel.SetActive(true);
        }

        public void OnExitButtonClick()
        {
            
        }

        // Обработчики кнопок на панели "New Game"
        public void OnAvatarClick()
        {
            ImageSlicesForNewGame.imageSlicesForNewGame = avatarSlices;
            SceneManager.LoadScene(puzzleScene);
        }

        public void OnDawkinsClick()
        {
            ImageSlicesForNewGame.imageSlicesForNewGame = dawkinsSlices;
            SceneManager.LoadScene(puzzleScene);
        }

        public void OnHelloClick()
        {
            ImageSlicesForNewGame.imageSlicesForNewGame = helloSlices;
            SceneManager.LoadScene(puzzleScene);
        }

        public void OnNewGamePanelBackClick()
        {
            mainMenuPanel.SetActive(true);
            newGamePanel.SetActive(false);
        }

        // Обработчики кнопок на панели "Options"
        public void OnOptionsPanelBackClick()
        {
            mainMenuPanel.SetActive(true);
            optionsPanel.SetActive(false);
        }

    }
}