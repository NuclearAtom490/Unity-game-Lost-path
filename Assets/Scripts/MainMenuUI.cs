using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level 1"); //Loads level 1
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings"); //Loads settings
    }

    public void QuitGame()
    {
        Application.Quit(); // Would quit the actual game if it was an application
        UnityEditor.EditorApplication.isPlaying = false; // Quits the play mode in unity editor
        Debug.Log("Quit Game"); 
    }
}