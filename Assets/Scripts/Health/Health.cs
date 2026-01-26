using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth;
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numOfFlashes;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth; // sets current health to starting health at the beginning of the game
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
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
            StartCoroutine(Invulnerability()); // Calls the IEnumerator
        }
        else
        {
            if (!dead) // Makes sure die animation doesnt play twice
            {
                anim.SetTrigger("die");

                //Player
                if  (CompareTag("Player"))
                {
                    GetComponent<PlayerMovement>().enabled = false; // Player cannot move once dead
                    Invoke(nameof(LoadDeathScreen), 1.5f); //loads the death scene after player die
                }

               //Enemy
                if (GetComponentInParent<EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false; // Enemy cannot move once dead
                if (GetComponent<EnemyScript>() != null)
                    GetComponent<EnemyScript>().enabled = false; //Enemy cannot attack once dead
                dead = true;

                
            }
            
        }
    }
    
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);//ignores collision of layers 10 and 11
        for (int i = 0; i < numOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f); // Changes player to red when hit
            yield return new WaitForSeconds(iFrameDuration / (numOfFlashes * 2));
            spriteRend.color = Color.white; // changes player back to white
            yield return new WaitForSeconds(iFrameDuration / (numOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);// doesnt ignore the collision
    }
}
