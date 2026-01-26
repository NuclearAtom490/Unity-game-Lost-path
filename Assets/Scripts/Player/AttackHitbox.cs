using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return; 

        Health hp = collision.GetComponentInParent<Health>();
        if (hp != null) hp.TakeDamage(1);
    }
}
