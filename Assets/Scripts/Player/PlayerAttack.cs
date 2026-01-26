using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    private float attackCooldown = 0.5f;
    [SerializeField] private Collider2D attackHitbox;   // drag AttackHitbox collider here
    [SerializeField] private float hitTime = 0.12f;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
   

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        if (attackHitbox != null) attackHitbox.enabled = false;

    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown)// Attacks if left mouse button clicked and cooldown timer is greater than the attack cooldown
        {
            cooldownTimer = 0f;
            anim.SetTrigger("Attack1");
            StartCoroutine(AttackWindow());
        } 

        cooldownTimer += Time.deltaTime;
    }

    private IEnumerator AttackWindow()
    {
        if (attackHitbox == null) yield break;

        attackHitbox.enabled = true;
        yield return new WaitForSeconds(hitTime);
        attackHitbox.enabled = false;
    }

    // Attack function
    //private void Attack()
    //{
    //    anim.SetTrigger("Attack1");
    //    cooldownTimer = 0;
   // }

   // private void OnTriggerEnter2D(Collider2D collision) // Deal damage to enemy
   // {
   //     if (!collision.CompareTag("Enemy")) return;

    //    Health hp = collision.GetComponentInParent<Health>();
   //     if (hp != null)
    //        hp.TakeDamage(1);
    //}




}