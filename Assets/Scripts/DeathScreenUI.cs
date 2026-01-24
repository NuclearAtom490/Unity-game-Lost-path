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
        SceneManager.LoadScene("Main Menu"); // Goes back to main menu
    }
}