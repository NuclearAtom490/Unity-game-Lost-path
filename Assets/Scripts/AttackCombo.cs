using UnityEngine;

public class AttackCombo : MonoBehaviour
{
    public Animator animator;

    private int comboStep = 0; // Stores which attack youre on
    private float comboTimer; // Tracks how long left to press attack again before combo ends
    public float comboWindow = 5f; // How long the combo lasts

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            comboStep++;// Increments combostep if left click is pressed
            Debug.Log("ATTACK pressed at: " + Time.time);
            if (comboStep > 3)
                comboStep = 1; // Loops back to Attack1 animation once it goes past 3

            animator.SetInteger("ComboStep", comboStep);
            animator.SetBool("IsAttacking", true); // Sets IsAttacking to true 
            animator.SetTrigger("Attack");

            comboTimer = comboWindow;
        }

        if (comboTimer > 0)
        {
            comboTimer -= Time.deltaTime;
            if (comboTimer <= 0)
            {
                ResetCombo(); // This whole thing counts down the combo timer
            }
        }
    }

    public void ResetCombo()
    {
        comboStep = 0; // Resets combo after player no longer attacking
        animator.SetInteger("ComboStep", 0);
        animator.SetBool("IsAttacking", false);
    }
}