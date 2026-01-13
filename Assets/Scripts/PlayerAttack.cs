using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackCooldown = 0.5f;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown) // Attacks if left mouse button clicked and cooldown timer is greater than the attack cooldown
            Attack();
            Debug.Log("Clicked - attacking");
        cooldownTimer += Time.deltaTime;
    }

    // Attack function
    private void Attack()
    {
        anim.SetTrigger("Attack1");
        cooldownTimer = 0;
    }





}