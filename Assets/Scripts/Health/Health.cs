using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth; // sets current health to starting health at the beginning of the game
        anim = GetComponent<Animator>();
    }
    void LoadDeathScreen()
    {
        SceneManager.LoadScene("Death screen");
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth); // Makes sure current health never goes below 0

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead) // Makes sure die animation doesnt play twice
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false; // Player cannot move once dead
                dead = true;

                Invoke(nameof(LoadDeathScreen), 1.5f); // loads the death scene after player dies
            }
            
        }
    }
 
}
