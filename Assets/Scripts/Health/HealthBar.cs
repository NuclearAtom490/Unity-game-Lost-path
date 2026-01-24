using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10; // Sets the players total health
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10; //This removes one hearth from the player at a time
    }
    
}
