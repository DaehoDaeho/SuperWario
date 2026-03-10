using UnityEngine;

public class GoalPortal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            GameManager.instance.ShowGameClearUI();
        }
    }
}
