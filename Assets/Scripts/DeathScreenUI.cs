using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level 1"); //Loads level 1
    }

    public void QuitGame()
    {
        Application.Quit(); // Would quit the actual game if it was an application
        UnityEditor.EditorApplication.isPlaying = false; // Quits the play mode in unity editor
        Debug.Log("Quit Game"); 
    }
}