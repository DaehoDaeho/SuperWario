using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if(playerHealth != null)
        {
            playerHealth.TakeDamage(1);
        }
    }
}
