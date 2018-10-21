using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleSceneUIBehaviour : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName;

    public void OnBackButtonClick()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
