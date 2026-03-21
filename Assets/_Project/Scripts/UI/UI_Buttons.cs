using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
    [SerializeField] private int MainMenuInt = 0;
    [SerializeField] private int TownSceneInt = 1;
    [SerializeField] private int LevelSceneInt = 2;

    public void OnStartButton()
    {
        SceneManager.LoadScene(TownSceneInt);
    }

    public void OnExitButton()
    {
        Debug.Log("Application Quit done");
        Application.Quit();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(LevelSceneInt);
    }

    public void ReturnToTown()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(TownSceneInt);
    }

    public void ReturnToMainMenu()
    {
       SceneManager.LoadScene(MainMenuInt);
        Time.timeScale = 1.0f;
    }
}
