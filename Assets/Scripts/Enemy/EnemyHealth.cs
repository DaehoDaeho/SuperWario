using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("적이 대미지를 입음" + amount);
        currentHealth = currentHealth - amount;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
