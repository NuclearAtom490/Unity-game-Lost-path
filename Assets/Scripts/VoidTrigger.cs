using UnityEngine;
using UnityEngine.SceneManagement;

public class VoidTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) //Checks if a 2d collider collides with another 2d collider
    {
        if (other.CompareTag("Player")) // Returns true if the object that touched the trigger has tag "Player"
        {
            SceneManager.LoadScene("Death screen"); // Load death screen
        }
    }
}